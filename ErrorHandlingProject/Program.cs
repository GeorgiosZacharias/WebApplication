using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
// test on this for example http://localhost:5084/api/ErrorHandling/division?numerator=10&denominator=5
var builder = WebApplication.CreateBuilder(args);
// Registers controller services so your app can use API controllers
builder.Services.AddControllers();
// Adds console logging so all logs appear in the terminal/console output
builder.Logging.AddConsole();

var app = builder.Build();

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Global Exception Caught: {ex.Message}"); // Logs the exception message to the console (useful for debugging)
        context.Response.StatusCode = 500;    // Sets the HTTP status code to 500 (Internal Server Error)
        await context.Response.WriteAsync("Unexpected error occurred. Please try again.");   // Sends a response body to the client explaining that something went wrong
    }
});
app.MapGet("/", () => "API is running");
app.UseRouting();// Enables endpoint routing so ASP.NET Core can match incoming requests to routes
app.MapControllers(); // Maps controller routes (e.g., [HttpGet], [HttpPost]) so they can receive requests

app.Run();