namespace DotBox.Api.Extensions;

public static class WebHostBuilderExtensions
{
    public static IWebHostBuilder Configure(this IWebHostBuilder builder)
    {
        builder.ConfigureKestrel(options =>
        {
            options.AllowSynchronousIO = true;
        })
        .ConfigureLogging((_, loggingBuilder) => loggingBuilder.ClearProviders());

        return builder;
    }
}
