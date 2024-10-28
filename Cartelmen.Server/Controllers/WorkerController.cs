using Cartelmen.Application.DTOs;
using Cartelmen.Application.Services;
using Cartelmen.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkerController : Controller
{
    private readonly IWorkerService _workerService;
    private readonly IValidator<WorkerDto> _validator;

    public WorkerController(IWorkerService workerService, IValidator<WorkerDto> validator)
    {
        _workerService = workerService;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IResult> Create([FromBody] WorkerDto worker)
    {
        var validationResult = await _validator.ValidateAsync(worker);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        await _workerService.Create(worker);
        return Results.Ok();

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var building = await _workerService.GetById(id);
        if (building == null)
        {
            return NotFound();
        }
        return Ok(building);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var buildings = await _workerService.GetAll();
        return Ok(buildings);
    }
}
