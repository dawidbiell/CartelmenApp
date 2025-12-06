
using Cartelmen.Domain.Entities;
using MediatR;

namespace Cartelmen.Application.CQRS.Assignments.Queries;

public class AssignmentsGetAllQuery : IRequest<IEnumerable<SpotPerson>>
{
    
}