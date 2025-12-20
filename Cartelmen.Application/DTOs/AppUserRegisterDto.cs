using System.ComponentModel.DataAnnotations;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.DTOs;

public class AppUserRegisterDto: AppUserLoginDto
{
    [Required]
    public required string Username { get; set; }
}