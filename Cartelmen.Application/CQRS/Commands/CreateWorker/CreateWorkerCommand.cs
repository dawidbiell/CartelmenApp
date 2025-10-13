using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using MediatR;

namespace Cartelmen.Application.CQRS.Commands.CreateWorker;

public class CreateWorkerCommand : WorkerDto, IRequest<Worker>
{
}