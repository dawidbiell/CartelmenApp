using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;

namespace Cartelmen.Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public BuildingService(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<Building> Create(BuildingDto buildingDto)
        {
            var building = _mapper.Map<Building>(buildingDto);
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