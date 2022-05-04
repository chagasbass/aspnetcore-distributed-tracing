using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Extensions.Extensions.OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace MinimalApi.Extensions.Extensions
{
    public static class DistributedTracingExtensions
    {
        public static IServiceCollection AddTelemetryTracing(this IServiceCollection services, IConfiguration configuration)
        {
            var agentHost = configuration["JaeggerConfiguration:AgentHost"];
            var agentPort = Convert.ToInt32(configuration["JaeggerConfiguration:AgentPort"]);

            services.AddOpenTelemetryTracing(traceProvider =>
            {
                traceProvider
                    .AddSource(OpenTelemetryExtensions.ServiceName)
                    .SetResourceBuilder(
                        ResourceBuilder.CreateDefault()
                            .AddService(serviceName: OpenTelemetryExtensions.ServiceName,
                                serviceVersion: OpenTelemetryExtensions.ServiceVersion))
                    .AddHttpClientInstrumentation()
                    .AddAspNetCoreInstrumentation()
                    .AddJaegerExporter(exporter =>
                    {
                        exporter.AgentHost = agentHost;
                        exporter.AgentPort = agentPort;
                    });
            });

            return services;
        }
    }
}
