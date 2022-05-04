using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Extensions.OpenTelemetry;
using MinimalApiUm.ApplicationServices.Dtos;
using System.Diagnostics;
using System.Text.Json;

namespace MinimalApiUm.ApplicationServices.Bases
{
    public abstract class BaseApplicationServices
    {
        private readonly ActivitySource _activitySource;
        private Activity _activity;

        protected BaseApplicationServices()
        {
            _activitySource = OpenTelemetryExtensions.CreateActivitySource();
        }

        public void StartActivitySource()
        {
            using var activity = _activitySource.StartActivity($"Construtor (ProdutoController/ProdutoApplicationServices)");
            activity!.SetTag("horario", $"{DateTime.Now:HH:mm:ss dd/MM/yyyy}");

            _activity = activity;
        }

        public CommandResult AddActivityData(InserirProdutoDto request, CommandResult commandResult)
        {
            _activity!.SetTag("ContratoRecebido", JsonSerializer.Serialize(request));
            _activity!.SetTag("Origem", OpenTelemetryExtensions.Local);
            _activity!.SetTag("Retorno", JsonSerializer.Serialize(commandResult));

            return commandResult;
        }
    }
}
