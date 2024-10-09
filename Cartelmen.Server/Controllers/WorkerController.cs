using Cartelmen.Application.Services;
using Cartelmen.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

[Route("api/[controller]")]
public class WorkerController : Controller
{
    private readonly IWorkerService _workerService;

    public WorkerController(IWorkerService workerService)
    {
        _workerService = workerService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Worker worker)
    {
        return Ok(await _workerService.Create(worker));
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
