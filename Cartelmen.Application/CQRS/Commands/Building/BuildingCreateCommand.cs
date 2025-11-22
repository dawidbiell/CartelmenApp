using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Commands.Building;

public class BuildingCreateCommand : BuildingDto , IRequest<int>
{
    
}