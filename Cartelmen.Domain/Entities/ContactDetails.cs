using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartelmen.Domain.Entities;

public class ContactDetails
{
    [Key]
    public required int Id { get; set; }

    [Column(TypeName = "varchar(16)")]
    public string? Phone { get; set; }

    [Column(TypeName = "varchar(64)")]
    public string? Email { get; set; }

    public Employee Employee { get; set; }
    //public Employee EmployeeId { get; set; }

}