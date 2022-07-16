using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace BestPractices.Api.Extensions;

public static class HealthCheckConfigureExtension
{
    public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/api/health",new HealthCheckOptions()
        {
            ResponseWriter = async (context, report) =>
            {
                await context.Response.WriteAsync("OK");
            }
        });
        return app;
    }
}