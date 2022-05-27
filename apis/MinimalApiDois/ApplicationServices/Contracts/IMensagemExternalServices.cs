using MinimalApiDois.Domain.Entities;

namespace MinimalApiDois.ApplicationServices.Contracts
{
    public interface IMensagemExternalServices
    {
        Task EnviarMensagemAsync(Mensagem mensagem);
    }
}
