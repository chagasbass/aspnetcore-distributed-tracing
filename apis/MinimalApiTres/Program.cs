using Microsoft.AspNetCore.Mvc;
using MinimalApi.Extensions;
using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer()
                .AddMinimalApiHttpLogging()
                .AddBaseConfigurationOptionsPattern(configuration)
                .AddSwaggerDocumentation(configuration)
                .AddMinimalApiPerformanceBoost()
                .AddTelemetryTracing(configuration)
                .AddApiVersioning(x => x.DefaultApiVersion = ApiVersion.Default);


var app = builder.Build();

app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

MapEndpointActions(app);

app.Run();


void MapEndpointActions(WebApplication app)
{
    app.MapPost("/mensagens", async (
        [FromBody] string mensagem) =>
    {
        var commandResult = new CommandResult(true, "A mensagem foi enviada com sucesso");

        return Results.Created("/mensagens", commandResult);

    }).Produces<CommandResult>(StatusCodes.Status201Created)
      .WithName("EnviarMensagemAsync")
      .WithTags("Mensagens");
}
