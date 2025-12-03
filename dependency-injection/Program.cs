var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
public interface IMyInterface
{
    void LogCreation(string message);
}

public class MyService : IMyService
{
    private readonly int _serviceId;
    public MyService()
    {
        _serviceId = new Random().Next(100000, 999999);
    }
}
app.MapGet("/", () => "Hello World!");

app.Run();
