using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Worker.Commands;

public class WorkerCreateCommand : WorkerDto, IRequest<Guid>
{
}