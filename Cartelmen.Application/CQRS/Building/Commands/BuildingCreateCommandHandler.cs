using AutoMapper;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Building.Commands;

public class BuildingCreateCommandHandler(
    IMapper mapper,
    IBuildingRepository buildingRepository)
    : IRequestHandler<BuildingCreateCommand, int>
{

    public async Task<int> Handle(BuildingCreateCommand request, CancellationToken cancellationToken)
    {
        // Validation DTO by DataAnnotations
        var building = mapper.Map<Domain.Entities.Building>(request);
        await buildingRepository.AddAsync(building);
        return building.Id;
    }
}
