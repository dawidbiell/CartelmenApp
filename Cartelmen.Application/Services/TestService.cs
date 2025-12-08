using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;

namespace Cartelmen.Application.Services
{
    public class TestService : ITestService
    {
        private readonly ISpotRepository _spotRepository;
        private readonly ISpotPersonsRepository _spotPersonsRepository;
        private readonly IMapper _mapper;

        public TestService(
            ISpotRepository spotRepository,
            ISpotPersonsRepository spotPersonsRepository,
            IMapper mapper)
        {
            _spotRepository = spotRepository;
            _spotPersonsRepository = spotPersonsRepository;
            _mapper = mapper;
        }
        
        public async Task<SpotPersonsDto?> PersonsGetAll(int id, CancellationToken ct)
        {
            var spot = await _spotPersonsRepository.AssignmentGetBySpotIdAsync(id, ct);
            if (spot is null)  return null;
            
            var dto =  new SpotPersonsDto()
            {
                Spot = _mapper.Map<SpotDto>(spot)
            };
            
            var personDtos = spot.Persons
                .Select(person => _mapper.Map<PersonDto>(person))
                .ToList();

            dto.Persons = personDtos;
            
            return dto;
        }
        
        

        public async Task<Spot> Create(SpotDto buildingDto, CancellationToken ct)
        {
            var building = _mapper.Map<Spot>(buildingDto);
            return await _spotRepository.AddAsync(building, ct);
        }

        public async Task<IEnumerable<SpotDto>> GetAll(CancellationToken ct)
        {
            var list = await _spotRepository.GetAllAsync(ct);
            var dtos = _mapper.Map<IEnumerable<SpotDto>>(list);
            return dtos;
        }
        

        public async Task<Spot?> GetById(int id, CancellationToken ct)
        {
            return await _spotRepository.GetByIdAsync(id, ct);
        }

        public async Task<Spot?> Update(Spot building, CancellationToken ct)
        {
            return await _spotRepository.UpdateAsync(building, ct);
        }

        public async Task<bool> DeleteById(int id, CancellationToken ct)
        {
            return await _spotRepository.DeleteByIdAsync(id, ct);
        }
    }
}