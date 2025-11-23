using Cartelmen.Application.CQRS.Person.Commands;
using Cartelmen.Application.CQRS.Person.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController(
    IMediator mediator,
    IValidator<PersonCreateCommand> validator) : Controller
{
    [HttpPost]
    public async Task<IResult> Create(PersonCreateCommand createCommand)
    {
        var validationResult = await validator.ValidateAsync(createCommand);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var entity = await mediator.Send(createCommand);
        return Results.Ok(entity);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var entity = await mediator.Send(new PersonGetByIdQuery(id));
        return Ok(entity);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await mediator.Send(new PersonGetAllQuery());
        return Ok(entities);
    }
}
