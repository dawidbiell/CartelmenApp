using Cartelmen.Domain.Entities;

namespace Cartelmen.Domain.Interfaces;

public interface ISpotPersonsRepository: ICrudRepository<SpotPerson>
{
    Task<List<SpotPerson>> AssignmentsGetAllAsync(CancellationToken cancellationToken);
    Task<Spot?> AssignmentGetBySpotIdAsync(int spotIds, CancellationToken cancellationToken);
    Task<SpotPerson?> FindAssigment(int spotId, int personId, CancellationToken cancellationToken);
    Task<int> AssignManyAsync(List<SpotPerson?> assignments, CancellationToken cancellationToken);
}