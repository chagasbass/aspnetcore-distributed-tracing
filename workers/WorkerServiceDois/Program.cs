using MinimalApi.Extensions.Extensions;
using WorkerServiceDois;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTelemetryTracing();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
