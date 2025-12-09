using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Queries;

public class SpotPersonsGetAllQuery(int spotId) : IRequest<SpotPersonsDto?>
{
    public int SpotId { get; } = spotId;
}