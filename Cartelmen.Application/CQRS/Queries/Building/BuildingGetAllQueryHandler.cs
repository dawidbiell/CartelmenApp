using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Queries.Building;

public class BuildingsGetAllQueryHandler:  IRequestHandler<BuildingsGetAllQuery, IEnumerable<BuildingDto>>
{
    private readonly IBuildingRepository  _buildingRepository;
    private readonly IMapper _mapper;

    public BuildingsGetAllQueryHandler(IBuildingRepository  buildingRepository, IMapper mapper)
    {
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<BuildingDto>> Handle(BuildingsGetAllQuery request, CancellationToken cancellationToken)
    {
        var buildings = await _buildingRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<BuildingDto>>(buildings);
        return dtos;
    }
}