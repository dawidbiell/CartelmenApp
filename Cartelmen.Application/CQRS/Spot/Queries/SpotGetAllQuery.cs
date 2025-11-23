using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Queries;

public class SpotGetAllQuery : IRequest<IEnumerable<SpotDto>>
{
    
}