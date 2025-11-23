using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Queries;

public class SpotGetByIdQuery(int id) :  IRequest<SpotDto>
{
    public int Id { get; } = id;
}