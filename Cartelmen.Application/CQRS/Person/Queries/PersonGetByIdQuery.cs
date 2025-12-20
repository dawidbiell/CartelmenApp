using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Person.Queries;

public record PersonGetByIdQuery(int Id) : IRequest<PersonDto>;