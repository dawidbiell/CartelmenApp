using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Repositories
{
    public class SpotRepository(CartelmenDbContext dbContext) : ISpotRepository
    {
        public async Task<Spot> AddAsync(Spot spot, CancellationToken ct)
        {
            dbContext.Spot.Add(spot);
            await dbContext.SaveChangesAsync(ct);
            return spot;
        }

        public async Task<IEnumerable<Spot>> GetAllAsync(CancellationToken ct)
        {
            return await dbContext.Spot
                .IgnoreQueryFilters()
                .ToListAsync(cancellationToken: ct);
        }

        public async Task<Spot?> GetByIdAsync(int id, CancellationToken ct)
        {
            return await dbContext.Spot.FindAsync(id, ct);
        }

        public async Task<Spot?> UpdateAsync(Spot spot, CancellationToken ct)
        {
            dbContext.Spot.Update(spot);
            var result = await dbContext.SaveChangesAsync(ct);
            return result > 0 ? spot : null;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct)
        {
            var result = await dbContext.Spot
                .Where(b => b.Id == id && !b.IsDeleted)
                .ExecuteUpdateAsync(b => b
                    .SetProperty(building => building.IsDeleted ,true)
                    .SetProperty(building => building.DeletedAtUtc , DateTime.UtcNow),
                    ct
                );

            return result > 0;
        }
    }
}