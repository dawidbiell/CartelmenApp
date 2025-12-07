using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Repositories
{
    public class SpotRepository : ISpotRepository
    {
        private readonly CartelmenDbContext _dbContext;

        public SpotRepository(CartelmenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Spot> AddAsync(Spot spot, CancellationToken ct)
        {
            _dbContext.Spot.Add(spot);
            await _dbContext.SaveChangesAsync();
            return spot;
        }

        public async Task<IEnumerable<Spot>> GetAllAsync(CancellationToken ct)
        {
            return await _dbContext.Spot
                .IgnoreQueryFilters()
                .ToListAsync();
        }

        public async Task<Spot?> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _dbContext.Spot.FindAsync(id);
        }

        public async Task<Spot?> UpdateAsync(Spot spot, CancellationToken ct)
        {
            _dbContext.Spot.Update(spot);
            var result = await _dbContext.SaveChangesAsync(ct);
            return result > 0 ? spot : null;
        }

        public async Task<bool> DeleteByIdAsync(int id, CancellationToken ct)
        {
            var result = await _dbContext.Spot
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