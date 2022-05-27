using MinimalApi.Extensions.Entities;
using MinimalApi.Extensions.Extensions.OpenTelemetry;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MinimalApiTres
{
    public class MinimalApi3Extensions
    {
        private readonly ActivitySource _activitySource;

        public MinimalApi3Extensions()
        {
            _activitySource = OpenTelemetryExtensions.CreateActivitySource();
        }

        public static string GetActualAsyncMethodName([CallerMemberName] string name = null) => name;

        public Activity StartActivitySource(string dados)
        {
            using var activity = _activitySource.StartActivity($"API Mensagens ({dados})");
            activity!.SetTag("horario", $"{DateTime.Now:HH:mm:ss dd/MM/yyyy}");

            return activity;
        }

        public IResult AddActivityData(Activity activity, string mensagem, CommandResult commandResult)
        {
            activity!.SetTag("ContratoRecebido", mensagem);
            activity!.SetTag("Origem", OpenTelemetryExtensions.Local);
            activity!.SetTag("Retorno", JsonSerializer.Serialize(commandResult));

            return Results.Created("/mensagens", commandResult);
        }
    }
}
