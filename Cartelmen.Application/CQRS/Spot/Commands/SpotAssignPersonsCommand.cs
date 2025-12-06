using System.Runtime.InteropServices.JavaScript;
using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Commands;

public class SpotAssignPersonsCommand(int spotId, SpotAssigmentDto[] spotAssigmentDtos) :  IRequest<int>
{
    public int SpotId { get; } = spotId;
    public SpotAssigmentDto[] SpotAssigmentDtos { get; } = spotAssigmentDtos;
}