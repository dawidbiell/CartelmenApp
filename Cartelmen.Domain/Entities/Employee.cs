using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartelmen.Domain.Entities
{
    public class Employee
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string FirstName { get; set; } = default!;

        [Required]
        [Column(TypeName = "varchar(64)")]
        public string LastName { get; set; } = default!;

        public DateTime? HiringDate { get; set; }

        public decimal PayRate { get; set; }

        //public ContactDetails Contact { get; set; }
        //public int ContactId { get; set; }



    }
}
