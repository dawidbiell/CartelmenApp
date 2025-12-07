using Cartelmen.Application.CQRS.Assignments.Commands;
using Cartelmen.Application.CQRS.Building.Queries;
using Cartelmen.Application.CQRS.Spot.Commands;
using Cartelmen.Application.CQRS.Spot.Queries;
using Cartelmen.Application.DTOs;
using Cartelmen.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpotsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISpotService _service;

        public SpotsController(IMediator mediator, ISpotService service)
        {
            _mediator = mediator;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpotCreateCommand  createCommand)
        {
            
            var entityId = await _mediator.Send(createCommand);
            return Ok(entityId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var entity = await _service.GetById(id, ct);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _mediator.Send(new SpotGetAllQuery());
            return Ok(entities);
        }
        
        [HttpPost("{Id}/persons")]
        public async Task<IActionResult> AssignMany(int Id, [FromBody] AssignmentDto[] assignments, CancellationToken cancellationToken)
        {
            var results = await _mediator.Send(new AssignPersonsCommand(Id,  assignments), cancellationToken);
            if (results > 0)
            {
                return Ok();
            }
            return NoContent();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, Building building)
        //{
        //    if (id != building.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var updatedBuilding = await _buildingService.UpdateAsync(building);
        //    return Ok(updatedBuilding);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteById(int id)
        //{
        //    var result = await _buildingService.DeleteByIdAsync(id);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}
    }
}