using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using static System.Net.WebRequestMethods;

namespace EventService.API;

public static class ServiceExtensionTelemetry
{
    public static IServiceCollection AddTelemetry(this IServiceCollection services)
    {
        services.AddOpenTelemetryTracing(tracerProviderBuilder =>
        {
            tracerProviderBuilder
            .AddSource("EventService1")
            .AddJaegerExporter(c =>
            {
                c.AgentHost = "simplest-agent";
                c.AgentPort = 6831;
            })
            .SetResourceBuilder(
                ResourceBuilder.CreateDefault()
                    .AddService(serviceName: "EventService", serviceVersion: "1.0.0"))
            .AddHttpClientInstrumentation()
            .AddAspNetCoreInstrumentation()
            .AddSqlClientInstrumentation();
        });

        return services;
    }
}
