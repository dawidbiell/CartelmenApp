using Cartelmen.Domain.Entities;

namespace Cartelmen.Domain.Interfaces
{
    public interface ISpotRepository
    {
        Task<Spot> AddAsync(Spot spot, CancellationToken cancellationToken);
        Task<Spot?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Spot>> GetAllAsync(CancellationToken cancellationToken);
        Task<Spot?> UpdateAsync(Spot spot, CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(int id, CancellationToken cancellationToken);
    }
}