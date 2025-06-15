namespace DotBox.Api.Extensions;

public static class MiddlewareExtensions
{
    private const string CorsPolicy = nameof(CorsPolicy);

    public static void ConfigureMiddlewares(this WebApplication app)
    {
        app.UseCors(CorsPolicy)
            .UseHsts()
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            })
            .UseSwagger()
            .UseSwaggerUI();
    }
}
