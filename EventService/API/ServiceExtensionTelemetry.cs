﻿using OpenTelemetry.Resources;
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
                c.AgentHost = "jaeger-collector.istio-system";
                c.AgentPort = 14268;
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
