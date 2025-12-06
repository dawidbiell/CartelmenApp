using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Commands;

public class SpotAssignPersonsCommandHandler(
    ISpotPersonsRepository spotRepository,
    IPersonRepository personRepository) 
    : IRequestHandler<SpotAssignPersonsCommand, int>
{


    public async Task<int> Handle(SpotAssignPersonsCommand request, CancellationToken cancellationToken)
    {
        var assignments = new List<SpotPerson?>();
        foreach (var spotAssignment in request.SpotAssigmentDtos)
        {
            var assignedPerson = await spotRepository.FindAssigment(request.SpotId, spotAssignment.PersonId, cancellationToken);
            if (assignedPerson is not null) continue;
            
            var person = await personRepository.GetByIdAsync(spotAssignment.PersonId, cancellationToken);
            if (person is null) continue;
            var assignment = new SpotPerson()
            {
                SpotId = request.SpotId,
                PersonId = spotAssignment.PersonId,
                AssignmentDate =  spotAssignment.AssignmentDate,
                PayRate = spotAssignment.PayRate ?? (person?.PayRate ?? 0),
            };
            assignments.Add(assignment);
        }

        var result = await spotRepository.AssignManyAsync(assignments, cancellationToken);

        return assignments.Count;
    }
}