using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Worker.Queries;

public class WorkerGetAllQuery : IRequest<IEnumerable<WorkerDto>>
{
    
}