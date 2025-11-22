using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Building.Queries;

public class BuildingsGetAllQuery : IRequest<IEnumerable<BuildingDto>>
{
    
}