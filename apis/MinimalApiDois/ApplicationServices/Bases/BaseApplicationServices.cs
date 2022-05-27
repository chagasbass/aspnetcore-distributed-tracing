using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Extensions.OpenTelemetry;
using MinimalApiDois.Domain.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace MinimalApiDois.ApplicationServices.Bases
{
    public abstract class BaseApplicationServices<T>
    {
        private readonly ActivitySource _activitySource;

        protected BaseApplicationServices()
        {
            _activitySource = OpenTelemetryExtensions.CreateActivitySource();
        }

        public Activity StartActivitySource(string dados)
        {
            using var activity = _activitySource.StartActivity($"API Categorias ({dados})");
            activity!.SetTag("horario", $"{DateTime.Now:HH:mm:ss dd/MM/yyyy}");

            return activity;
        }

        public CommandResult AddActivityData(Activity activity, Categoria request, CommandResult commandResult)
        {
            activity!.SetTag("ContratoRecebido", request);
            activity!.SetTag("Origem", OpenTelemetryExtensions.Local);
            activity!.SetTag("Retorno", JsonSerializer.Serialize(commandResult));

            return commandResult;
        }

        public CommandResult AddActivityData(Activity activity, Guid request, CommandResult commandResult)
        {
            activity!.SetTag("ContratoRecebido", request);
            activity!.SetTag("Origem", OpenTelemetryExtensions.Local);
            activity!.SetTag("Retorno", JsonSerializer.Serialize(commandResult));

            return commandResult;
        }
    }
}
