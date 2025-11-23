using Cartelmen.Domain.Entities;

namespace Cartelmen.Domain.Interfaces
{
    public interface ISpotRepository
    {
        Task<Spot> AddAsync(Spot spot);
        Task<Spot?> GetByIdAsync(int id);
        Task<IEnumerable<Spot>> GetAllAsync();
        Task<Spot?> UpdateAsync(Spot spot);
        Task<bool> DeleteByIdAsync(int id);
    }
}