using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<TimeTracker?> GetByKeyAsync(int spotPersonId, DateOnly date, CancellationToken cancellationToken)
    {
        var output = await dbContext.TimeTracker
            .Where(tt => tt.SpotPersonId == spotPersonId) 
            .Where (tt => tt.WorkDate == date)
            .FirstOrDefaultAsync(cancellationToken);
        
        return output;
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

    public Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }


}