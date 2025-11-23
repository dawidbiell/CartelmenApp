using AutoMapper;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Person.Commands;

public class PersonCreateCommandHandler : IRequestHandler<PersonCreateCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IPersonRepository _repository;

    public PersonCreateCommandHandler(IMapper mapper, IPersonRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Guid> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Entities.Person>(request);
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}