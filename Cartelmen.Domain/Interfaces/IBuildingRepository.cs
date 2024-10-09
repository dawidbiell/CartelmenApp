using Cartelmen.Domain.Entities;

namespace Cartelmen.Domain.Interfaces
{
    public interface IBuildingRepository
    {
        Task<Building> AddAsync(Building building);
        Task<Building?> GetByIdAsync(int id);
        Task<IEnumerable<Building>> GetAllAsync();
        Task<Building?> UpdateAsync(Building building);
        Task<bool> DeleteByIdAsync(int id);
    }
}