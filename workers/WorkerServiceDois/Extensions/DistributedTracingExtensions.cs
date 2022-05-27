using MinimalApi.Extensions.Extensions.OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace MinimalApi.Extensions.Extensions
{
    public static class DistributedTracingExtensions
    {
        public static IServiceCollection AddTelemetryTracing(this IServiceCollection services)
        {
            var agentHost = "localhost";
            var agentPort = 6831;

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
