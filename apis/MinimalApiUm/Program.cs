using Microsoft.AspNetCore.Mvc;
using MinimalApi.Extensions;
using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Extensions;
using MinimalApiUm.ApplicationServices.Contracts;
using MinimalApiUm.ApplicationServices.Dtos;
using MinimalApiUm.Extensions;

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

MapProdutoActions(app);

app.Run();


void MapProdutoActions(WebApplication app)
{
    app.MapPost("/produtos", async (InserirProdutoDto inserirAlunoDto,
                                    IProdutoApplicationServices produtoServices) =>
     {
         var commandResult = (CommandResult)await produtoServices.InserirProdutoAsync(inserirAlunoDto);

         return commandResult.Success != false
          ? Results.CreatedAtRoute("InserirProdutosAsync", commandResult)
          : Results.BadRequest(commandResult);

     }).Produces<CommandResult>(StatusCodes.Status201Created)
       .Produces(StatusCodes.Status400BadRequest)
       .WithName("InserirProdutosAsync")
       .WithTags("Produtos - Escrita");
}