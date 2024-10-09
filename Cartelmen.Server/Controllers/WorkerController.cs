using Cartelmen.Application.Services;
using Cartelmen.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

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
}
