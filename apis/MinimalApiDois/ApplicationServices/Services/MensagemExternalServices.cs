using Microsoft.Extensions.Options;
using MinimalApi.Shared;
using MinimalApiDois.ApplicationServices.Contracts;

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

        public async Task EnviarMensagemAsync(string mensagem)
        {
            var externalClient = _httpClient.CreateClient();

            var urlConsumo = $"{_baseConfigurationOptions.URlConsumo}";

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(mensagem),
                RequestUri = new Uri(urlConsumo)
            };

            await externalClient.SendAsync(requestMessage);
        }
    }
}
