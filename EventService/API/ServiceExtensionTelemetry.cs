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
            .AddSource("EventService")
            .AddJaegerExporter(c =>
            {
                c.AgentHost = "simplest-agent";
                c.AgentPort = 6831;
                c.Endpoint = new Uri("http://10.244.0.18:14268/api/traces");
            })
            .SetResourceBuilder(
                ResourceBuilder.CreateDefault()
                    .AddService(serviceName: "EventService1", serviceVersion: "1.0.0"))
            .AddHttpClientInstrumentation()
            .AddAspNetCoreInstrumentation()
            .AddSqlClientInstrumentation();
        });

        return services;
    }
}
