using Cartelmen.Application.CQRS.Commands.WorkerCreate;
using Cartelmen.Application.CQRS.Queries.WorkersGetAll;
using Cartelmen.Application.CQRS.Queries.WorkersGetById;
using Cartelmen.Application.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkersController(
    IMediator mediator,
    IValidator<WorkerCreateCommand> validator) : Controller
{
    [HttpPost]
    public async Task<IResult> Create(WorkerCreateCommand createCommand)
    {
        var validationResult = await validator.ValidateAsync(createCommand);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        await mediator.Send(new WorkerCreateCommand());
        return Results.Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var worker = await mediator.Send(new WorkersGetByIdQuery(id));
        return Ok(worker);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var workers = await mediator.Send(new WorkersGetAllQuery());
        return Ok(workers);
    }
}
