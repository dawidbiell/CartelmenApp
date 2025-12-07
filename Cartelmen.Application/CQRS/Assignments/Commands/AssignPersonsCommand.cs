using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Assignments.Commands;

public class AssignPersonsCommand(int spotId, PersonAssignmentDto[] spotAssigmentDtos) :  IRequest<int>
{
    public int SpotId { get; } = spotId;
    public PersonAssignmentDto[] SpotAssigmentDtos { get; } = spotAssigmentDtos;
}