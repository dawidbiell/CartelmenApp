using Cartelmen.Application.CQRS.Assignments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentsController(
    IMediator mediator) 
    : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var assignments = await mediator.Send(new AssignmentsGetAllQuery());
        return Ok(assignments);
    }
}