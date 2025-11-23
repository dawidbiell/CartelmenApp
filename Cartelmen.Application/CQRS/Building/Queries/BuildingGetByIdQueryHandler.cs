using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Building.Queries;

public class BuildingGetByIdQueryHandler :  IRequestHandler<BuildingGetByIdQuery,BuildingDto>
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;

    public BuildingGetByIdQueryHandler(IBuildingRepository repository, IMapper mapper)
    {
        _buildingRepository = repository;
        _mapper = mapper;
    }

    public async Task<BuildingDto> Handle(BuildingGetByIdQuery request, CancellationToken cancellationToken)
    {
        var building = await _buildingRepository.GetByIdAsync(request.Id);
        var dto = _mapper.Map<BuildingDto>(building);
        return dto;
    }
}