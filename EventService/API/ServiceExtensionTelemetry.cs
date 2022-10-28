using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

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
                c.Endpoint = new Uri("http://jaeger-collector.istio-system.svc:14268/api/traces");
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
