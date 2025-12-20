using System.ComponentModel.DataAnnotations;

namespace Cartelmen.Application.DTOs;
public class SpotDto
{

    // Validation DTO by DataAnnotations
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [StringLength(255, MinimumLength = 3)]
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? StartDate { get; set; }

    public string? Country { get; set; } 
    public string? City  { get; set; } 
    public string? Street  { get; set; }
    public string? PostalCode { get; set; }
    
}
