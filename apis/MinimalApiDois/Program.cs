using Microsoft.AspNetCore.Mvc;
using MinimalApi.Extensions;
using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Extensions;
using MinimalApiDois.ApplicationServices.Contracts;
using MinimalApiDois.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer()
                .AddMinimalApiHttpLogging()
                .AddBaseConfigurationOptionsPattern(configuration)
                .AddSwaggerDocumentation(configuration)
                .AddMinimalApiPerformanceBoost()
                .AddDbContextInMemory()
                .AddHttpClientResilience()
                .AddDependencyInjection()
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


MapCategoriaActions(app);

app.Run();

void MapCategoriaActions(WebApplication app)
{
    app.MapGet("/categorias", async (
       [FromQuery] Guid id,
       ICategoriaApplicationServices categoriaServices) =>
    {
        var commandResult = await categoriaServices.BuscarCategoriaAsync(id);

        return commandResult.Success != false
        ? Results.Ok(commandResult)
        : Results.BadRequest(commandResult);

    }).Produces<CommandResult>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status400BadRequest)
       .WithName("BuscarCategoriaAsync")
       .WithTags("Categorias");
}