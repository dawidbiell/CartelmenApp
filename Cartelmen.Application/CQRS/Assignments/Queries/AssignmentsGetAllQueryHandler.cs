using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Assignments.Queries;

public class AssignmentsGetAllQueryHandler : IRequestHandler<AssignmentsGetAllQuery, IEnumerable<SpotPerson>>
{
    private readonly ISpotPersonsRepository _repository;

    public AssignmentsGetAllQueryHandler(ISpotPersonsRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<SpotPerson>> Handle(AssignmentsGetAllQuery request, CancellationToken ct)
    {
        var output = await _repository.AssignmentsGetAllAsync(ct);
        return output;
    }
}