using Cartelmen.Application.CQRS.Assignments.Queries;
using Cartelmen.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

public class AssignmentsController(
    IMediator mediator,
    ISpotPersonsRepository spotPersonsRepository) 
    : AppBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        // var assignments = await mediator.Send(new AssignmentsGetAllQuery());
        var assignments = await spotPersonsRepository.AssignmentsGetAllAsync(ct);
        return Ok(assignments);
    }
}