using MinimalApi.Extensions.Extensions.OpenTelemetry;
using System.Diagnostics;
using System.Text.Json;
using WorkerServiceUm.Entidades;

namespace WorkerServiceUm.Serviços
{
    public class DataService
    {
        private readonly ActivitySource _activitySource;

        public DataService()
        {
            _activitySource = OpenTelemetryExtensions.CreateActivitySource();
        }

        public Activity StartActivitySource(string nomeWorker)
        {
            using var activity = _activitySource.StartActivity($"{nomeWorker}");
            activity!.SetTag("horario", $"{DateTime.Now:HH:mm:ss dd/MM/yyyy}");

            return activity;
        }

        public void AddActivityData(Activity activity, Produto request)
        {
            activity!.SetTag("ContratoRecebido", JsonSerializer.Serialize(request));
            activity!.SetTag("Origem", OpenTelemetryExtensions.Local);
        }
    }
}
