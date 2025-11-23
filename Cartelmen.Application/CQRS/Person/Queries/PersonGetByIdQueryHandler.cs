using AutoMapper;
using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Person.Queries;

public class PersonGetByIdQueryHandler : IRequestHandler<PersonGetByIdQuery, PersonDto>
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository  _repository;

    public PersonGetByIdQueryHandler(IMapper mapper, IPersonRepository repository)
    {
         _mapper = mapper;
        _repository = repository;
    }

    public async Task<PersonDto> Handle(PersonGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        var dto = _mapper.Map<PersonDto>(entity);
        return  dto;
    }
}