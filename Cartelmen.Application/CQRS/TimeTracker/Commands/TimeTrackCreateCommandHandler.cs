using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.TimeTracker.Commands;

public class TimeTrackCreateCommandHandler(
    ITimeTrackerRepository timeTrackerRepository,
    ISpotPersonsRepository spotPersonsRepository) 
    : IRequestHandler<TimeTrackCreateCommand, int>
{
    public async Task<int> Handle(TimeTrackCreateCommand request, CancellationToken ct)
    {
        // TODO validacja klucza TimeTracker [spotPersonId+ date]
        var timeLog = new Domain.Entities.TimeTracker();
        var spotPerson = await spotPersonsRepository.GetByIdAsync(request.SpotPersonId, ct);   
        if (spotPerson is null)
        {
            throw new ArgumentNullException($"{nameof(spotPerson)} assignments not exist");
        }
        
        timeLog.SpotPersonId = request.SpotPersonId;
        timeLog.WorkDate = DateOnly.FromDateTime(request.Date);
        timeLog.WorkTime = request.WorkTime;
        timeLog.PayRate = request.PayRate ?? spotPerson.PayRate;
        
        await timeTrackerRepository.AddAsync(timeLog, ct);
        
        
        return 1;
    }
}