using Microsoft.Extensions.Options;
using MinimalApi.Shared;
using MinimalApiDois.ApplicationServices.Contracts;
using MinimalApiDois.Domain.Entities;
using System.Text;
using System.Text.Json;

namespace MinimalApiDois.ApplicationServices.Services
{
    public class MensagemExternalServices : IMensagemExternalServices
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly BaseConfigurationOptions _baseConfigurationOptions;

        public MensagemExternalServices(IHttpClientFactory httpClient,
                                      IOptions<BaseConfigurationOptions> options)
        {
            _httpClient = httpClient;
            _baseConfigurationOptions = options.Value;
        }

        public async Task EnviarMensagemAsync(Mensagem mensagem)
        {
            var externalClient = _httpClient.CreateClient();

            var urlConsumo = $"{_baseConfigurationOptions.URlConsumo}";

            var json = JsonSerializer.Serialize(mensagem);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, urlConsumo);
            requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

            await externalClient.SendAsync(requestMessage);
        }
    }
}
