using System.ComponentModel.DataAnnotations;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.DTOs;

public class AppUserCreateDto
{
    [Required]
    public required string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Required]
    [MinLength(4)]
    public required string Password { get; set; }
}