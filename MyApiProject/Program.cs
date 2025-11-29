using System.Collections.Generic;
using System.Linq;
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

app.MapPost("/items", (Item newItem) =>
{
    newItem.Id = items.Count + 1;
    items.Add(newItem);
    return Results.Created($"/items/{newItem.Id}", newItem);
});

app.MapPut("/items/{id}", (int id, Item updatedItem) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    if (item is null) return Results.NotFound();
    item.Name = updatedItem.Name;
    return Results.Ok(item);
});
app.MapDelete("items/{id}", (int id) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    if (item is null) return Results.NotFound();
    items.Remove(item);
    return Results.NoContent();
});

app.MapGet("/", () => "Welcome to the Simple Web API!");

app.Run();