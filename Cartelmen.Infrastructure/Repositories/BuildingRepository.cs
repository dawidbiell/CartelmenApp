using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly CartelmenDbContext _dbContext;

        public BuildingRepository(CartelmenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Building> AddAsync(Building building)
        {
            _dbContext.Buildings.Add(building);
            await _dbContext.SaveChangesAsync();
            return building;
        }

        public async Task<IEnumerable<Building>> GetAllAsync()
        {
            return await _dbContext.Buildings
                .IgnoreQueryFilters()
                .ToListAsync();
        }

        public async Task<Building?> GetByIdAsync(int id)
        {
            return await _dbContext.Buildings.FindAsync(id);
        }

        public async Task<Building?> UpdateAsync(Building building)
        {
            _dbContext.Buildings.Update(building);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? building : default;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var result = await _dbContext.Buildings
                .Where(b => b.Id == id && !b.IsDeleted)
                .ExecuteUpdateAsync(b => b
                    .SetProperty(b => b.IsDeleted ,true)
                    .SetProperty(b => b.DeletedAtUtc , DateTime.UtcNow)
                );

            return result > 0;
        }
    }
}