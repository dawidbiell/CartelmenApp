using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Person.Commands;

public class PersonCreateCommand : PersonDto, IRequest<Guid>
{
}