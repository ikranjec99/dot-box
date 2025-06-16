using DotBox.Api.Settings;
using DotBox.Core.Business.Implementations;
using DotBox.Core.Business.Interfaces;
using DotBox.Core.Configuration;
using DotBox.Core.DataAccess;
using DotBox.Core.DataAccess.DropBoxDb.Implementations;
using DotBox.Core.DataAccess.DropBoxDb.Interfaces;
using Microsoft.AspNetCore.Mvc.Versioning;
using Serilog;

namespace DotBox.Api.Extensions;

public static class IServiceCollectionExtensions
{
    private const string CorsPolicy = nameof(CorsPolicy);

    private static IServiceCollection AddBusinessLayer(this IServiceCollection services) =>
        services
            .AddSingleton<IFolderHandler, FolderHandler>()
            .AddSingleton<ISqlLogger, SqlLogger>();

    private static IServiceCollection AddDataAccessLayer(this IServiceCollection services) =>
        services
            .AddSingleton<IFolderRepository, FolderRepository>();

    private static IServiceCollection SetupSerilog(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var loggerConfiguration = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Console();

        Log.Logger = loggerConfiguration.CreateLogger();

        return services;
    }

    private static IServiceCollection AddSettings(this IServiceCollection services, AppSettings appSettings)
    {
        services
            .AddSingleton<IConnectionStringConfiguration>(appSettings.ConnectionStrings)
            .AddSingleton<ISqlLoggerConfiguration>(appSettings.SqlLogger);

        return services;
    }

    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IWebHostEnvironment webHostEnvironment,
        IConfiguration configuration,
        AppSettings appSettings)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy, builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        services.AddMvc();

        services
            .AddRouting()
            .AddSettings(appSettings)
            .AddBusinessLayer()
            .AddDataAccessLayer()
            .AddLogging(loggingBuilder => loggingBuilder.ClearProviders())
            .SetupSerilog(configuration);

        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "DotBox API",
                Version = "1.0"
            });
        });

        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddApiVersioning();

        return services;
    }
}
