using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;

namespace Cartelmen.Infrastructure.Repositories;

public class TimeTrackerRepository(CartelmenDbContext dbContext) : ITimeTrackerRepository
{
    public async Task<TimeTracker?> AddAsync(TimeTracker? entity, CancellationToken cancellationToken = default)
    {
        if (entity is null) return entity;
        
        dbContext.TimeTracker.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public Task<IEnumerable<TimeTracker>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TimeTracker?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TimeTracker?> UpdateAsync(TimeTracker entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}