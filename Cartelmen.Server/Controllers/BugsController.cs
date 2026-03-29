using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Server.Controllers;

public class BugsController : AppBaseController
{
    // GET
    [HttpGet("auth")]
    public IActionResult GetAuthError()
    {
        return Unauthorized();
    }
    
    [HttpGet("bad-request")]
    public IActionResult GetBadRequestError()
    {
        return BadRequest("Bad Request response");
    }
    
    [HttpGet("server-error")]
    public IActionResult GetServerError()
    {
        throw new Exception("Server Error");
    }
    
    [HttpGet("not-found")]
    public IActionResult GetNotFoundError()
    {
        return NotFound();
    }
}