using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cartelmen.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Domain.Entities
{
    public class Worker : ISoftDeletable
    {
        [Key]
        public required Guid Id { get; set; }
        [Required] [MaxLength(64)]
        public string FirstName { get; set; } = default!;
        [Required] [MaxLength(64)]
        public string LastName { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateOnly? HiringDate { get; set; }

        [Column(TypeName = "money")]
        public decimal PayRate { get; set; } =default!;

        [ForeignKey("ContactId")]
        public ContactDetails Contact { get; set; }
        //public Guid ContactId { get; set; }
        public IList<Building> Buildings { get; set; } = new List<Building>();

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
