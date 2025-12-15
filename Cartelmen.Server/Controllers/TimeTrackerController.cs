using Cartelmen.Application.CQRS.TimeTracker.Commands;
using Cartelmen.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeTrackerController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> LogTime(TimeTrackCreateCommand timeTrackCreateCommand)
    {
        var result = await mediator.Send(timeTrackCreateCommand);

        if (result > 1) return Ok(result);
        return BadRequest();

    }
}