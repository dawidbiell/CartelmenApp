
using Cartelmen.Domain.Entities;
using MediatR;

namespace Cartelmen.Application.CQRS.Assignments.Queries;

public class AssignmentsGetAllQuery : IRequest<SpotPerson>, IRequest<IEnumerable<SpotPerson>>
{
    
}