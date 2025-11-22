using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Building.Commands;

public class BuildingCreateCommand : BuildingDto , IRequest<int>
{
    
}