using Microsoft.Extensions.Options;
using MinimalApi.Shared;
using MinimalApiUm.ApplicationServices.Contracts;

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

        public async Task<string> BuscarCategoriaAsync(Guid id)
        {
            var externalClient = _httpClient.CreateClient();

            var urlConsumo = $"{_baseConfigurationOptions.URlConsumo}?={id}";

            var categoriaResponse = await externalClient.GetFromJsonAsync<string>(urlConsumo);

            return categoriaResponse;
        }
    }
}
