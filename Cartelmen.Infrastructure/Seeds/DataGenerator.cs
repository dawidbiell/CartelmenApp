using Bogus;
using Cartelmen.Domain.Entities;
using Cartelmen.Infrastructure.Persistence;

namespace Cartelmen.Infrastructure.Seeds
{
    public static class DataGenerator
    {
        public static void Seed(CartelmenDbContext context)
        {
            var locale = "pl";
            Randomizer.Seed = new Random(777);

            

            var contactDetailsGenerator = new Faker<ContactDetails>(locale)
                .Rules((f, w) =>
                {
                    w.Id = Guid.NewGuid();
                    w.Phone = f.Phone.PhoneNumber();
                    w.Email = f.Internet.Email();

                });

            var workerGenerator = new Faker<Worker>(locale)
                    .Rules((f, w) =>
                    {
                        //w.Id = Guid.NewGuid();
                        w.FirstName = f.Person.FirstName;
                        w.LastName = f.Name.LastName();
                        w.HiringDate = f.Random.Number(1, 5) switch
                        {
                            1 => null,
                            5 => f.Date.FutureDateOnly(),
                            _ => f.Date.RecentDateOnly(),
                        };
                        w.PayRate = f.Random.Number(15, 25);
                        w.Contact = contactDetailsGenerator.Generate();

                    });
            var workers = workerGenerator.Generate(35).ToList();


            var addressGenerator = new Faker<Address>(locale)
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

            //var id = 1;
            var buildingGenerator = new Faker<Building>(locale)
                //.StrictMode()
                //.RuleFor(b => b.Id, f => id++)
                .RuleFor(b => b.Name, f => f.Company.CompanyName())
                .RuleFor(b => b.Description, f => f.Company.CatchPhrase())
                .RuleFor(b => b.StartDate, f => f.Date.BetweenDateOnly(DateOnly.Parse("2024-04-01"),DateOnly.Parse("2024-04-01")).OrNull(f,.1f))
                .RuleFor(b => b.Address, () => addressGenerator.Generate())
                .RuleFor(b => b.Workers, f => f.PickRandom(workers,8).ToList());

            var dataSeed = buildingGenerator.Generate(5);

             context.AddRange(dataSeed);
             context.SaveChanges();
        }
    }
}