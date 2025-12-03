using Cartelmen.Domain.Entities;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.Spot.Commands;

public class SpotAssignPersonsCommandHandler(
    ISpotPersonsRepository repository) 
    : IRequestHandler<SpotAssignPersonsCommand, int>
{


    public async Task<int> Handle(SpotAssignPersonsCommand request, CancellationToken cancellationToken)
    {
        var assigments = new List<SpotPerson?>();
        foreach (var personId in request.PersonIds)
        {
            var spotPerson = await repository.FindAssigment(request.SpotId, personId, cancellationToken);
            if (spotPerson is null)
            {
                assigments.Add(spotPerson);
            }
        }

        var result = await repository.AssignManyAsync(assigments, cancellationToken);

        return result;
    }
}