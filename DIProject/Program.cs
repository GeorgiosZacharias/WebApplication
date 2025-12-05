using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMyService, MyService>();
//builder.Services.AddScoped<IMyService, MyService>();
var app = builder.Build();

app.Use(async (context, next) =>
{
    context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("First instance");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Second instance");
    await next.Invoke();
});


app.MapGet("/", (IMyService myService) =>
{
    myService.LogCreation("Root");
    return Results.Ok("Check console for service creation log");
}
);
app.Run();