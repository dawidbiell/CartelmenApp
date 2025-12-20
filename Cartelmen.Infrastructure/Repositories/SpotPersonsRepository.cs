using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Repositories;

public class SpotPersonsRepository(CartelmenDbContext dbContext) : ISpotPersonsRepository
{
    public async Task<List<SpotPerson>> AssignmentsGetAllAsync(CancellationToken ct)
    {
         var results = await dbContext.SpotPerson
            .AsNoTracking()
            .Include(s=>s.Spot)
            .Include(s=>s.Person)
            .ToListAsync(ct);

         return results;
    }

    public async Task<Spot?> AssignmentGetBySpotIdAsync(int spotIds, CancellationToken ct)
    {
        return await dbContext.Spot
            .Include(s => s.Persons)
            .AsNoTracking()
            .Where(s => s.Id == spotIds)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<SpotPerson?> FindAssigment(int spotId, int personId, CancellationToken ct = default)
    {
        return await dbContext.SpotPerson
            .Where(sp => sp.SpotId == spotId && sp.PersonId == personId)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<int> AssignManyAsync(List<SpotPerson?> assignments, CancellationToken ct)
    {
        dbContext.SpotPerson.AddRange(assignments);
        return await dbContext.SaveChangesAsync(ct);
    }

    public async Task<SpotPerson?> AddAsync(SpotPerson? entity, CancellationToken cancellationToken = default)
    {
        if (entity is null) return entity;
        
        dbContext.SpotPerson.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public Task<IEnumerable<SpotPerson>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<SpotPerson?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var spotPerson = await dbContext.SpotPerson.FindAsync(id,cancellationToken);
        return spotPerson;
    }

    public Task<SpotPerson?> UpdateAsync(SpotPerson? entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}