using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.DTOs;

public class AppUserDto
{
    public required string Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Token { get; set; }
    
    public static AppUserDto FromAppUser(AppUser appUser)
    {
        return new AppUserDto()
        {
            Id = appUser.Id.ToString(),
            Email = appUser.Email,
            Username = appUser.Username,
            Token = "",
        };
    }
}