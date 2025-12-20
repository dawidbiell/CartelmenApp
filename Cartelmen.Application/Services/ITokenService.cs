using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;

namespace Cartelmen.Application.Services;

public interface ITokenService
{
    string CreateToken(AppUser user);
}