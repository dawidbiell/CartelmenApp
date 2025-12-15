using Cartelmen.Application.DTOs;
using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.TimeTracker.Commands;

public class TimeTrackCreateCommandHandler(
    ITimeTrackerRepository timeTrackerRepository,
    ISpotPersonsRepository spotPersonsRepository) 
    : IRequestHandler<TimeTrackCreateCommand, int>
{
    public async Task<int> Handle(TimeTrackCreateCommand request, CancellationToken cancellationToken)
    {
        var spotPerson = await spotPersonsRepository.GetByIdAsync(request.SpotPersonId, cancellationToken);   
        //TODO dokonczyc tworzenie entry
        return 0;
    }
}