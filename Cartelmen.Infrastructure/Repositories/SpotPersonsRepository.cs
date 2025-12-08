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

    public async Task<SpotPerson?> FindAssigment(int spotId, Guid personId, CancellationToken ct = default)
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
}