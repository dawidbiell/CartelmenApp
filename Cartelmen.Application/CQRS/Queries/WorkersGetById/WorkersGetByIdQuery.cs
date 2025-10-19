using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using MediatR;

namespace Cartelmen.Application.CQRS.Queries.WorkersGetById;

public record WorkersGetByIdQuery(Guid Id) : IRequest<WorkerDto>;