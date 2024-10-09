using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;

namespace Cartelmen.Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<Building> Create(Building building)
        {
            return await _buildingRepository.AddAsync(building);
        }

        public async Task<IEnumerable<Building>> GetAll()
        {
            return await _buildingRepository.GetAllAsync();
        }

        public async Task<Building?> GetById(int id)
        {
            return await _buildingRepository.GetByIdAsync(id);
        }

        public async Task<Building?> Update(Building building)
        {
            return await _buildingRepository.UpdateAsync(building);
        }

        public async Task<bool> DeleteById(int id)
        {
            return await _buildingRepository.DeleteByIdAsync(id);
        }
    }
}