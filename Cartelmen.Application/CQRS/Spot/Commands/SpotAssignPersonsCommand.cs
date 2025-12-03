using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Commands;

public class SpotAssignPersonsCommand(int spotId, Guid[] personIds) : IRequest<int>
{
    public int SpotId { get; } = spotId;
    public Guid[] PersonIds { get; } = personIds;
}