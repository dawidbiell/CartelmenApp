using System.ComponentModel.DataAnnotations;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.DTOs;

public class AppUserLoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default;
    
    [Required]
    [MinLength(4)]
    public string Password { get; set; }  = default;
}