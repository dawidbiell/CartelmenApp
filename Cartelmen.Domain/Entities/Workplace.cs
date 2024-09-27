using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartelmen.Domain.Entities
{
    public class Workplace
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Description { get; set; }

        public AddressDetails Address { get; set; }
        public int AddressId { get; set; }

        public DateTime StartDate { get; set; }
    }
}
