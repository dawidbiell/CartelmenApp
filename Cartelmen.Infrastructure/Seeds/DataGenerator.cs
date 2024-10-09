using Bogus;
using Bogus.DataSets;
using Cartelmen.Domain.Entities;
using Cartelmen.Infrastructure.Persistence;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Entity = Cartelmen.Domain.Entities;

namespace Cartelmen.Infrastructure.Seeds
{
    public class DataGenerator
    {
        private readonly CartelmenDbContext _dbContext;
        private const string Locale = "pl";

        public DataGenerator(CartelmenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            Randomizer.Seed = new Random(777);

            if (!await _dbContext.Database.CanConnectAsync()) return;
            


            var workerGenerator = new Faker<Worker>(Locale)
                    .Rules((f, w) =>
                    {
                        //w.Id = Guid.NewGuid();
                        w.FirstName = f.Name.FirstName( Name.Gender.Male);
                        w.LastName = f.Name.LastName(Name.Gender.Male);
                        w.HiringDate = f.Random.Number(1, 5) switch
                        {
                            1 => null,
                            5 => f.Date.FutureDateOnly(),
                            _ => f.Date.RecentDateOnly(),
                        };
                        w.PayRate = f.Random.Number(15, 25);
                        w.Contact = w.GenerateContact(Locale);

                    });
            var workers = workerGenerator.Generate(35).ToList();


            var addressGenerator = new Faker<Entity.Address>(Locale)
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

            var buildingGenerator = new Faker<Building>(Locale)
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .RuleFor(b => b.Description, f => f.Company.CatchPhrase())
                .RuleFor(b => b.StartDate, f => f.Date.BetweenDateOnly(DateOnly.Parse("2024-01-01"),DateOnly.Parse("2024-12-31")).OrNull(f,.1f))
                .RuleFor(b => b.Address, () => addressGenerator.Generate())
                .RuleFor(b => b.Workers, f => f.PickRandom(workers, 8).ToList());


            //buildings
            List<Building> buildings;
            if (_dbContext.Buildings.Any())
            {
                buildings = await _dbContext.Buildings.ToListAsync();
            }
            else
            {
                buildings = buildingGenerator.Generate(5).ToList();

                await _dbContext.AddRangeAsync(buildings);
                await _dbContext.SaveChangesAsync();
            }


            //timetracks
            if (_dbContext.TimeTracks.Any()) return;

            var timeTrackGenerator = new Faker<TimeTrack>(Locale)
                .Rules((f, tt) =>
                {
                    tt.WorkDate = f.Date.RecentDateOnly(7);
                    tt.WorkHours = f.Random.Int(0, 24 * 4) * 0.25m;
                    var building = f.PickRandom(buildings);
                    tt.BuildingId = building.Id;
                    tt.WorkerId = f.PickRandom(building.Workers).Id;
                });


            var timeTracks = Enumerable.Empty<TimeTrack>().ToList();
            do
            {
                var timeTrack = timeTrackGenerator.Generate();

                var keyExists = timeTracks
                    .Any(tt => $"{tt.WorkDate}{tt.BuildingId}{tt.WorkerId}" == $"{timeTrack.WorkDate}{timeTrack.BuildingId}{timeTrack.WorkerId}");

                if (!keyExists)
                {
                    timeTracks.Add(timeTrack);
                }
            } while (timeTracks.Count <= 100);


            await _dbContext.AddRangeAsync(timeTracks);
            await _dbContext.SaveChangesAsync();


        }

        
    }
}