using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;

namespace Cartelmen.Application.Services
{
    public class SpotService : ISpotService
    {
        private readonly ISpotRepository _buildingRepository;
        private readonly IMapper _mapper;

        public SpotService(ISpotRepository spotRepository, IMapper mapper)
        {
            _buildingRepository = spotRepository;
            _mapper = mapper;
        }

        public async Task<Spot> Create(SpotDto buildingDto, CancellationToken ct)
        {
            var building = _mapper.Map<Spot>(buildingDto);
            return await _buildingRepository.AddAsync(building, ct);
        }

        public async Task<IEnumerable<SpotDto>> GetAll(CancellationToken ct)
        {
            var list = await _buildingRepository.GetAllAsync(ct);
            var dtos = _mapper.Map<IEnumerable<SpotDto>>(list);
            return dtos;
        }

        public async Task<Spot?> GetById(int id, CancellationToken ct)
        {
            return await _buildingRepository.GetByIdAsync(id, ct);
        }

        public async Task<Spot?> Update(Spot building, CancellationToken ct)
        {
            return await _buildingRepository.UpdateAsync(building, ct);
        }

        public async Task<bool> DeleteById(int id, CancellationToken ct)
        {
            return await _buildingRepository.DeleteByIdAsync(id, ct);
        }
    }
}