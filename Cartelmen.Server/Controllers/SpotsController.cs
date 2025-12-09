using Cartelmen.Application.CQRS.Assignments.Commands;
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

        public SpotsController(IMediator mediator)
        {
            _mediator = mediator;
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
            var entity = await _mediator.Send(new SpotGetByIdQuery(id), ct);
            if (entity is null)
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
        
        [HttpPost("{id}/persons")]
        public async Task<IActionResult> AssignMany(int id, [FromBody] PersonAssignmentDto[] assignments, CancellationToken cancellationToken)
        {
            var results = await _mediator.Send(new AssignPersonsCommand(id,  assignments), cancellationToken);
            if (results > 0)
            {
                return Ok();
            }
            return NoContent();
        }
        
        [HttpGet("{id}/persons")]
        public async Task<IActionResult> SpotPersonsGetAll(int id, CancellationToken ct)
        {
            var results = await  _mediator.Send(new SpotPersonsGetAllQuery(id), ct);
            return results is not null 
                ? Ok(results) 
                : NoContent();
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