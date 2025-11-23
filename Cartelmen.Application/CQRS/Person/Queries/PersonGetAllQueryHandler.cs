using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Person.Queries;

public class PersonGetAllQueryHandler : IRequestHandler<PersonGetAllQuery, IEnumerable<PersonDto>>
{
    private readonly IMapper  _mapper;
    private readonly IPersonRepository  _repository;

    public PersonGetAllQueryHandler( IMapper mapper, IPersonRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<PersonDto>> Handle(PersonGetAllQuery request, CancellationToken cancellationToken)
    {
        var list = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<PersonDto>>(list);
        return dtos;
    }
}