using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Queries.Building;

public class BuildingsGetAllQuery : IRequest<IEnumerable<BuildingDto>>
{
    
}