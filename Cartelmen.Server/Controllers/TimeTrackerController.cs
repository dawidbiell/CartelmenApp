using Cartelmen.Application.CQRS.TimeTracker.Commands;
using Cartelmen.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

public class TimeTrackerController(IMediator mediator) : AppBaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> LogTime(TimeTrackCreateCommand timeTrackCreateCommand)
    {
        var result = await mediator.Send(timeTrackCreateCommand);

        return Ok(result);
    }
}