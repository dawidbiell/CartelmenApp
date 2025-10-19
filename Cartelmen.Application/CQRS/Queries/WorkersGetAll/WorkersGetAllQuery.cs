using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Queries.WorkersGetAll;

public class WorkersGetAllQuery : IRequest<IEnumerable<WorkerDto>>
{
    
}