using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using MediatR;

namespace Cartelmen.Application.CQRS.Commands.WorkerCreate;

public class WorkerCreateCommand : WorkerDto, IRequest<Guid>
{
}