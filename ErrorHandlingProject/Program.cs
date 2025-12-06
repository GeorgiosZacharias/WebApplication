using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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
        Console.WriteLine($"Global Exception Caught: {ex.Message}");
        context.Response.StatusCode = 500;    // FIXED: correct context usage
        await context.Response.WriteAsync("Unexpected error occurred. Please try again.");
    }
});

app.UseRouting();
app.MapControllers();

app.Run();