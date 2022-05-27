using Microsoft.AspNetCore.Mvc;
using MinimalApi.Extensions;
using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Extensions;
using MinimalApiDois.ApplicationServices.Contracts;
using MinimalApiDois.ApplicationServices.Dtos;
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

//app.UseHttpsRedirection();


MapCategoriaActions(app);

app.Run();

void MapCategoriaActions(WebApplication app)
{
    app.MapGet("/categorias/{id}", async (
       [FromRoute] Guid id,
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

    app.MapPost("/categorias", async (
        InserirCategoriaDto inserirCategoriaDto,
        ICategoriaApplicationServices categoriaServices) =>
    {
        var commandResult = (CommandResult)await categoriaServices.InserirCategoriaAsync(inserirCategoriaDto);

        return commandResult.Success != false
         ? Results.Created("InserirCategoriasAsync", commandResult)
         : Results.BadRequest(commandResult);

    }).Produces<CommandResult>(StatusCodes.Status201Created)
       .Produces(StatusCodes.Status400BadRequest)
       .WithName("InserirCategoriasAsync")
       .WithTags("Categorias");
}