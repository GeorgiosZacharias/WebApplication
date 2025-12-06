using Microsoft.AspNetCore.MVC;
using System;

[Route("api/[controller]")]
[ApiController]
public class ErrorHandlingController : ControllerBase
{
    [HttpGet("division")]
    public IActionResult GetDivisionResult(int numerator, int denominator)
    {
        try
        {
            var result = numerator / denominator; //basic division we check later if divided by zero in the catch
            return ok(result);
        }
        catch (DivideByZeroException)
        {
            return BadRequest("Cannot Divide by zero");
        }
    }
}