using Bogus;
using Cartelmen.Domain.Entities;
using Cartelmen.Infrastructure.Persistence;

namespace Cartelmen.Infrastructure.Seeds
{
    public class DataGenerator
    {
        public void Seed(CartelmenDbContext context)
        {
            var locale = "pl";
            Randomizer.Seed = new Random(777);

            var addressGenerator = new Faker<Address>(locale)
                .RuleFor(a => a.Country, f => f.Address.Country())
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Street, f => f.Address.StreetName())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

            var address = addressGenerator.Generate();

            var id = 1;
            var buildingGenerator = new Faker<Building>(locale)
                .StrictMode(true)
                .RuleFor(b=>b.Id, f => id++);


        }
    }
}
