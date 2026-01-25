using Cartelmen.Domain.Entities;

namespace Cartelmen.Domain.Interfaces;

public interface IAppUserRepository : ICrudRepository<AppUser>
{
    Task<AppUser?> GetByEmailAsync(string mail, CancellationToken cancellationToken  = default);
}