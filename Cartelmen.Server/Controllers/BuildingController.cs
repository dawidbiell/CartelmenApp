using Cartelmen.Application.Services;
using Cartelmen.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Building building)
        {
            var createdBuilding = await _buildingService.Create(building);
            return Ok(createdBuilding);
            //return CreatedAtAction(nameof(GetById), new { id = createdBuilding.Id }, createdBuilding);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var building = await _buildingService.GetByIdAsync(id);
        //    if (building == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(building);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var buildings = await _buildingService.GetAllAsync();
        //    return Ok(buildings);
        //}

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