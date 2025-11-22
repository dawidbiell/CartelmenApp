using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Queries.Worker;

public class WorkerGetAllQuery : IRequest<IEnumerable<WorkerDto>>
{
    
}