using Microsoft.AspNetCore.Mvc;
using system;

[Route("api/[controller]")]
[ApiController]
public class ErrorHandlingController : ControllerBase
{
    [HttpGet("division")]
    public IActionResult GetDivisionResult(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            return BadRequest("Cannot divide by zero");
        }

        var result = numerator / (double)denominator;
        return Ok(result);
    }
}