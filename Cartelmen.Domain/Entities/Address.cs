using System.ComponentModel.DataAnnotations;

namespace Cartelmen.Domain.Entities
{
    public class Address
    {
        [Key]
        public required int Id { get; set; }
        public string Country  { get; set; }
        public string City  { get; set; }
        public string PostalCode  { get; set; }
        public string Street  { get; set; }

        //public Workplace Workplace { get; set; }
        //public Workplace WorkplaceId { get; set; }
    }
}
