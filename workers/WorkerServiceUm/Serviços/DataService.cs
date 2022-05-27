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

        public void StartActivitySource(string nomeWorker, Produto request, Guid trackId)
        {
            using var activity = _activitySource.StartActivity($"{nomeWorker}");
            activity!.SetTag("horario", $"{DateTime.Now:HH:mm:ss dd/MM/yyyy}");
            activity!.SetTag("ContratoRecebido", JsonSerializer.Serialize(request));
            activity!.SetTag("Origem", OpenTelemetryExtensions.Local);
            activity!.SetTag("TrackId", trackId);
        }

    }
}
