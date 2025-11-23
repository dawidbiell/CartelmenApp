using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;

namespace Cartelmen.Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly ISpotRepository _buildingRepository;
        private readonly IMapper _mapper;

        public BuildingService(ISpotRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<Spot> Create(SpotDto buildingDto)
        {
            var building = _mapper.Map<Spot>(buildingDto);
            return await _buildingRepository.AddAsync(building);
        }

        public async Task<IEnumerable<SpotDto>> GetAll()
        {
            var list = await _buildingRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<SpotDto>>(list);
            return dtos;
        }

        public async Task<Spot?> GetById(int id)
        {
            return await _buildingRepository.GetByIdAsync(id);
        }

        public async Task<Spot?> Update(Spot building)
        {
            return await _buildingRepository.UpdateAsync(building);
        }

        public async Task<bool> DeleteById(int id)
        {
            return await _buildingRepository.DeleteByIdAsync(id);
        }
    }
}