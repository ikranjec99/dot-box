using DotBox.Api.Extensions;
using DotBox.Api.Settings;
using Serilog;
using System.Text.Json;

namespace DotBox.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.Configure();
        builder.Host.UseSerilog();

        var appSettings = builder.Configuration.Get<AppSettings>();
        Console.WriteLine(JsonSerializer.Serialize(appSettings, new JsonSerializerOptions { WriteIndented = true }));

        builder.Services.AddServices(builder.Environment, builder.Configuration, appSettings);

        var app = builder.Build();

        app.ConfigureMiddlewares();

        await app.RunAsync().ConfigureAwait(false);
    }
}
