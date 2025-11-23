using Cartelmen.Application.CQRS.Building.Queries;
using Cartelmen.Application.CQRS.Spot.Commands;
using Cartelmen.Application.CQRS.Spot.Queries;
using Cartelmen.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpotController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBuildingService _service;

        public SpotController(IMediator mediator, IBuildingService service)
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
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _mediator.Send(new SpotGetAllQuery());
            return Ok(entities);
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