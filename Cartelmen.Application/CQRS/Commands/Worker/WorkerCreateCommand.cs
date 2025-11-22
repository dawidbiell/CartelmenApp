using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Commands.Worker;

public class WorkerCreateCommand : WorkerDto, IRequest<Guid>
{
}