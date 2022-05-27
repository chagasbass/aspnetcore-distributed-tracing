using Microsoft.Extensions.Options;
using MinimalApi.Extensions.Entities;
using MinimalApi.Shared;
using MinimalApiUm.ApplicationServices.Contracts;
using MinimalApiUm.ApplicationServices.Dtos;
using System.Text;
using System.Text.Json;

namespace MinimalApiUm.ApplicationServices.Services
{
    public class CategoriaExternalServices : ICategoriaExternalServices
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly BaseConfigurationOptions _baseConfigurationOptions;

        public CategoriaExternalServices(IHttpClientFactory httpClient,
                                      IOptions<BaseConfigurationOptions> options)
        {
            _httpClient = httpClient;
            _baseConfigurationOptions = options.Value;
        }

        public async Task<CommandResult> BuscarCategoriaAsync(Guid id)
        {
            var externalClient = _httpClient.CreateClient();

            var urlConsumo = $"{_baseConfigurationOptions.URlConsumo}/{id}";

            var categoriaResponse = await externalClient.GetAsync(urlConsumo);

            var json = await categoriaResponse.Content.ReadAsStringAsync();
            var commandResult = JsonSerializer.Deserialize<CommandResult>(json);

            return commandResult;
        }

        public async Task<CommandResult> InserirCategoriaAsync(InserirCategoriaDto inserirCategoriaDto)
        {
            var externalClient = _httpClient.CreateClient();

            var urlConsumo = $"{_baseConfigurationOptions.URlConsumo}";
            var json = JsonSerializer.Serialize(inserirCategoriaDto);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, urlConsumo);
            requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var categoriaResponse = await externalClient.SendAsync(requestMessage);

            var jsonReturn = await categoriaResponse.Content.ReadAsStringAsync();
            var commandResult = JsonSerializer.Deserialize<CommandResult>(jsonReturn);

            return commandResult;
        }
    }
}
