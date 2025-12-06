using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Assignments.Commands;

public class AssignPersonsCommand(int spotId, AssignmentDto[] spotAssigmentDtos) :  IRequest<int>
{
    public int SpotId { get; } = spotId;
    public AssignmentDto[] SpotAssigmentDtos { get; } = spotAssigmentDtos;
}