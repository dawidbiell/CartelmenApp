using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Repositories;

public class AppUserRepository : IAppUserRepository
{
    private readonly CartelmenDbContext _context;

    public AppUserRepository(CartelmenDbContext context)
    {
        _context = context;
    }
    
    public Task<AppUser?> GetByEmailAsync(string mail, CancellationToken cancellationToken)
    {
        var user = _context.AppUsers.FirstOrDefaultAsync(a => a.Email.ToLower() == mail.ToLower(), cancellationToken);
        return user;
    }

    public async Task<AppUser?> AddAsync(AppUser? entity, CancellationToken cancellationToken = default)
    {
        if (entity is null) return null;
        _context.AppUsers.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return entity;
    }

    public Task<IEnumerable<AppUser>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<AppUser?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<AppUser?> UpdateAsync(AppUser? entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

