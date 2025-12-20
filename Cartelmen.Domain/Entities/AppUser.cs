namespace Cartelmen.Domain.Entities;

public class AppUser
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required byte[] Password { get; set; }
    public required byte[] HashSeed { get; set; }
}
    