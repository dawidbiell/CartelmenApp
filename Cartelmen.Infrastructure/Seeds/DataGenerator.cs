using Bogus;
using Bogus.DataSets;
using Cartelmen.Domain.Entities;
using Cartelmen.Infrastructure.Persistence;
using Address = Cartelmen.Domain.Entities.Address;

namespace Cartelmen.Infrastructure.Seeds
{
    public static class DataGenerator
    {
        private const string  Locale = "pl";
        
        public static void Seed(CartelmenDbContext context)
        {
            Randomizer.Seed = new Random(777);

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
                        w.Contact = w.GenerateContact();

                    });
            var workers = workerGenerator.Generate(35).ToList();


            var addressGenerator = new Faker<Address>(Locale)
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

            //var id = 1;
            var buildingGenerator = new Faker<Building>(Locale)
                //.StrictMode()
                //.RuleFor(b => b.Id, f => id++)
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .RuleFor(b => b.Description, f => f.Company.CatchPhrase())
                .RuleFor(b => b.StartDate, f => f.Date.BetweenDateOnly(DateOnly.Parse("2024-01-01"),DateOnly.Parse("2024-12-31")).OrNull(f,.1f))
                .RuleFor(b => b.Address, () => addressGenerator.Generate())
                .RuleFor(b => b.Workers, f => f.PickRandom(workers,8).ToList());

            var dataSeed = buildingGenerator.Generate(5);

             context.AddRange(dataSeed);
             context.SaveChanges();
        }

        private static ContactDetails GenerateContact(this Worker worker)
        {
            var contactDetail = new Faker<ContactDetails>(Locale)
                .Rules((f, w) =>
                {
                    w.Id = Guid.NewGuid();
                    w.Phone = f.Phone.PhoneNumber();
                    w.Email = f.Internet.Email(worker.FirstName, worker.LastName);

                })
                .Generate();
            return contactDetail;
        }
    }
}