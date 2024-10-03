using Bogus;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Infrastructure.Seeds
{
    internal static class DataGeneratorExtensions
    {
        public static ContactDetails GenerateContact(this Worker worker, string locale = "pl")
        {
            var contactDetail = new Faker<ContactDetails>(locale)
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
