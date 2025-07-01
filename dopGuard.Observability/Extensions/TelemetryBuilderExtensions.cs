using OpenTelemetry.Trace;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dopGuard.Observability.Extensions;

public static class TelemetryBuilderExtensions
{
    public static IServiceCollection AddDopGuardObservability(this IServiceCollection services, IConfiguration configs)
    {
//        var serviceName = configs["Otel:ServiceName"] ?? "dopGuard";
//        var serviceVersion = configs["Otel:ServiceVersion"] ?? "1.0.0";
        var otlpEndpoint = configs["Otel:Endpoint"] ?? "http://localhost:4318/v1/traces";

        services.AddOpenTelemetryTracing(builder =>
            {
                builder
//                    .SetResourceBuilder(ResourceBuilder.CreateDefault()
//                    .AddAspNetCoreInstrumentation()
//                    .AddHttpClientInstrumentation()
//                    .AddService(serviceName: serviceName, serviceVersion: serviceVersion)
                    .AddOtlpExporter(opt =>
                    {
                        opt.Endpoint = new Uri(otlpEndpoint);
                    });
            });

        return services;
    }
}