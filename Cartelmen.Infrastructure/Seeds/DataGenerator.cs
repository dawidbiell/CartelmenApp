using Bogus;
using Bogus.DataSets;
using Cartelmen.Domain.Entities;
using Cartelmen.Infrastructure.Persistence;
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
            


            var personGenerator = new Faker<Entity.Person>(Locale)
                    .Rules((f, p) =>
                    {
                        //w.Id = Guid.NewGuid();
                        p.FirstName = f.Name.FirstName( Name.Gender.Male);
                        p.LastName = f.Name.LastName(Name.Gender.Male);
                        p.HiringDate = f.Random.Number(1, 5) switch
                        {
                            1 => null,
                            5 => f.Date.FutureDateOnly(),
                            _ => f.Date.RecentDateOnly(),
                        };
                        p.PayRate = f.Random.Number(15, 25);
                        p.Contact = p.GenerateContact(Locale);

                    });
            var persons = personGenerator.Generate(35).ToList();


            var addressGenerator = new Faker<Entity.Address>(Locale)
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

            var spotGenerator = new Faker<Spot>(Locale)
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .RuleFor(b => b.Description, f => f.Company.CatchPhrase())
                .RuleFor(b => b.StartDate, f => f.Date.BetweenDateOnly(DateOnly.Parse("2024-01-01"), DateOnly.Parse("2024-12-31")).OrNull(f, .1f))
                .RuleFor(b => b.Address, () => addressGenerator.Generate())
                .RuleFor(b => b.Persons, f => f.PickRandom(persons, 5).ToList());


            //spots
            List<Spot> spots;
            if (_dbContext.Spot.Any())
            {
                spots = await _dbContext.Spot
                    .Include(s=>s.Persons)
                    .ToListAsync();
            }
            else
            {
                spots = spotGenerator.Generate(2).ToList();

                await _dbContext.AddRangeAsync(spots);
                await _dbContext.SaveChangesAsync();
            }
            
            //spotPerson
            var spotPersonGenerator = new Faker<SpotPerson>(Locale)
                .Rules((f, sp) =>
                {
                    var spot = f.PickRandom(spots);
                    var person = f.PickRandom(spot.Persons);
                    
                    sp.SpotId =  spot.Id;
                    sp.PersonId = person.Id;
                    sp.AssignmentDate = DateTime.Parse(spot.StartDate?.ToString() ?? "2025-01-01");
                    sp.PayRate = person.PayRate;

                });
            var spotPersons = spotPersonGenerator.Generate((int)(spots.Count * persons.Count * 0.6)).ToList();
            await _dbContext.AddRangeAsync(spotPersons);
            await _dbContext.SaveChangesAsync();
            
            //timetracks
            if (_dbContext.TimeTracks.Any()) return;

            var timeTrackerGenerator = new Faker<TimeTracker>(Locale)
                .Rules((f, tt) =>
                {
                    var spotPerson = f.PickRandom(spotPersons);
                    tt.SpotPersonId = spotPerson.Id;
                    tt.WorkDate = f.Date.RecentDateOnly(7);
                    tt.WorkTime = f.Random.Int(4, 12);
                    tt.PayRate = spotPerson.PayRate;
                    tt.UpdatedBy = "Bogus Faker";
                    tt.UpdatedAtUtc = DateTime.UtcNow;
                });


            var timeTracks = Enumerable.Empty<TimeTracker>().ToList();
            do
            {
                var timeTrack = timeTrackerGenerator.Generate();
            
                var keyExists = timeTracks
                    .Any(tt => $"{tt.WorkDate}{tt.SpotPersonId}" == $"{timeTrack.WorkDate}{timeTrack.SpotPersonId}");
            
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