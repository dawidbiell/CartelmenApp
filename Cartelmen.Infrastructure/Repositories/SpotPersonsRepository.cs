using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Repositories;

public class SpotPersonsRepository :ISpotPersonsRepository
{
    private readonly CartelmenDbContext _dbContext;

    public SpotPersonsRepository(CartelmenDbContext  dbContext )
    {
        _dbContext = dbContext;
    }


    public async Task<List<SpotPerson>> AssignmentsGetAllAsync(CancellationToken ct)
    {
        return await _dbContext.SpotPerson
            .Include(s => s.Spot)
            .Include(s => s.Person)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<Spot?> AssignmentGetBySpotIdAsync(int spotIds, CancellationToken ct)
    {
        return await _dbContext.Spot
            .Include(s => s.Persons)
            .AsNoTracking()
            .Where(s => s.Id == spotIds)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<SpotPerson?> FindAssigment(int spotId, Guid personId, CancellationToken ct = default)
    {
        return await _dbContext.SpotPerson
            .Where(sp => sp.SpotId == spotId && sp.PersonId == personId)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<int> AssignManyAsync(List<SpotPerson?> assignments, CancellationToken ct)
    {
        _dbContext.SpotPerson.AddRange(assignments);
        return await _dbContext.SaveChangesAsync(ct);
    }
}