using Bogus;
using Cartelmen.Domain.Entities;
using Person = Cartelmen.Domain.Entities.Person;

namespace Cartelmen.Infrastructure.Seeds
{
    internal static class DataGeneratorExtensions
    {
        public static ContactDetails GenerateContact(this Person person, string locale = "pl")
        {
            var contactDetail = new Faker<ContactDetails>(locale)
                .Rules((f, p) =>
                {
                    p.Id = Guid.NewGuid();
                    p.Phone = f.Phone.PhoneNumber();
                    p.Email = f.Internet.Email(person.FirstName, person.LastName);

                })
                .Generate();
            return contactDetail;
        }
    }
}
