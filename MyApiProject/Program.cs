using WebApplication.Models;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
var items = new List<Item>();
// Basic routes
app.MapGet("/items", () => items);
app.MapGet("/items/{id}", (int id) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    return item is not null ? Results.Ok(item) : Results.NotFound();
});

app.MapGet("/", () => "Welcome to the Simple Web API!");

app.Run();