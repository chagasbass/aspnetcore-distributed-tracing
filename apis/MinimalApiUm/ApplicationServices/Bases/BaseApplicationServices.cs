using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Extensions.OpenTelemetry;
using MinimalApiUm.ApplicationServices.Dtos;
using MinimalApiUm.Domain.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace MinimalApiUm.ApplicationServices.Bases
{
    public abstract class BaseApplicationServices<T>
    {
        private readonly ActivitySource _activitySource;
        private Activity _activity;

        protected BaseApplicationServices()
        {
            _activitySource = OpenTelemetryExtensions.CreateActivitySource();
        }

        public Activity StartActivitySource(string nomeController)
        {
            using var activity = _activitySource.StartActivity($"API de Produtos ({nomeController})");
            activity!.SetTag("horario", $"{DateTime.Now:HH:mm:ss dd/MM/yyyy}");

            return activity;
        }

        public void AddActivityData(Activity activity, InserirProdutoDto request, object data)
        {
            activity!.SetTag("ContratoRecebido", JsonSerializer.Serialize(request));
            activity!.SetTag("Origem", OpenTelemetryExtensions.Local);
            activity!.SetTag("Retorno", JsonSerializer.Serialize(data));
        }

        public Categoria RecuperarDadosDeCategoria(CommandResult categoriaResultado)
        {
            var dadoRecebido = categoriaResultado.Data;

            var categoriaJson = dadoRecebido.ToString();

            return JsonSerializer.Deserialize<Categoria>(categoriaJson);
        }
    }
}
