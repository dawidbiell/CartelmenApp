using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.Person.Queries;

public class PersonGetAllQuery : IRequest<IEnumerable<PersonDto>>
{
    
}