using MinimalApi.Extensions.Extensions;
using WorkerServiceUm;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTelemetryTracing();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
