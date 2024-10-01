using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartelmen.Domain.Entities
{
    public class Worker
    {
        [Key]
        public required Guid Id { get; set; }
        [Required] [MaxLength(64)]
        public string FirstName { get; set; } = default!;
        [Required] [MaxLength(64)]
        public string LastName { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateOnly? HiringDate { get; set; }
        public decimal PayRate { get; set; } =default!;


        public ContactDetails Contact { get; set; }
        public IList<Building> Buildings { get; set; } = new List<Building>();



    }
}
