using Cartelmen.Application.DTOs;
using MediatR;

namespace Cartelmen.Application.CQRS.TimeTracker.Commands;

public class TimeTrackCreateCommand : TimeTrackCreateDto , IRequest<int>
{
    
}