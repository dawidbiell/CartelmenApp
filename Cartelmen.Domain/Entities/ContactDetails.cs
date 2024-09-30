using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartelmen.Domain.Entities;

public class ContactDetails
{
    [Key]
    public Guid Id { get; set; }
    [MaxLength(16)]
    public string? Phone { get; set; }
    [MaxLength(64)]
    public string? Email { get; set; }

    public Worker Worker { get; set; }
    public Guid WorkerId { get; set; }

}