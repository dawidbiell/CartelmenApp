using Cartelmen.Domain.Entities;

namespace Cartelmen.Domain.Interfaces;

public interface ITimeTrackerRepository : ICrudRepository<TimeTracker>
{
    Task<TimeTracker?> GetByKeyAsync(int spotPersonId, DateOnly date, CancellationToken cancellationToken  = default);
}