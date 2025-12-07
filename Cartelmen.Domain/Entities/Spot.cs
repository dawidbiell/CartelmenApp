using Cartelmen.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartelmen.Domain.Entities
{
    public class Spot :ISoftDeletable
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public required string Name { get; set; }
        
        [MaxLength(64)]
        public string? Description { get; set; }
        
        [Column(TypeName = "date")]
        public DateOnly? StartDate { get; set; }
        


        public Address Address { get; set; } = default!;
        public ICollection<Person> Persons { get; set; } = [];

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
