namespace MinimalApiDois.ApplicationServices.Contracts
{
    public interface IMensagemExternalServices
    {
        Task EnviarMensagemAsync(string mensagem);
    }
}
