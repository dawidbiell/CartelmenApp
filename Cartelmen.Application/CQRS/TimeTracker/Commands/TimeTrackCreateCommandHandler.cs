using Cartelmen.Domain.Interfaces;
using MediatR;

namespace Cartelmen.Application.CQRS.TimeTracker.Commands;

public class TimeTrackCreateCommandHandler(
    ITimeTrackerRepository timeTrackerRepository,
    ISpotPersonsRepository spotPersonsRepository) 
    : IRequestHandler<TimeTrackCreateCommand, Domain.Entities.TimeTracker?>
{
    public async Task<Domain.Entities.TimeTracker?> Handle(TimeTrackCreateCommand request, CancellationToken ct)
    {
        // TODO validacja klucza TimeTracker [spotPersonId+ date]
        var timeLog = new Domain.Entities.TimeTracker();
        
        var spotPerson = await spotPersonsRepository.GetByIdAsync(request.SpotPersonId, ct);   
        if (spotPerson is null)
        {
            throw new ArgumentException($"{nameof(spotPerson)} assignments not exist");
        }

        var getLog = await timeTrackerRepository.GetByKeyAsync(
                request.SpotPersonId, 
                request.Date,
                ct);
        if (getLog is not null)
        {
            throw new ArgumentException($"[SpotPerson: {request.SpotPersonId}, WorkDate:{request.Date}] key exists");
        }
        
        timeLog.SpotPersonId = request.SpotPersonId;
        timeLog.WorkDate = request.Date;
        timeLog.WorkTime = request.WorkTime;
        timeLog.PayRate = request.PayRate ?? spotPerson.PayRate;
        
        await timeTrackerRepository.AddAsync(timeLog, ct);
        
        
        return timeLog;
    }
}