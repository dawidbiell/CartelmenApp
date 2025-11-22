using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Worker.Queries;

public record WorkersGetByIdQuery(Guid Id) : IRequest<WorkerDto>;