var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMyService, MyService>();
var app = builder.Build();
app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("first middleware");
    await next.Invoke();
});
app.Use(async (context, next) =>
{
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("second middleware");
    await next.Invoke();
});

app.MapGet("/", (IMyService myService) =>
{
    myService.LogCreation("Root");
    return Results.Ok("Check console for service creation log");
});

app.Run();




