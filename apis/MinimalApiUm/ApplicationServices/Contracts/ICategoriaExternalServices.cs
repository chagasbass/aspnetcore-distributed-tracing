namespace MinimalApiUm.ApplicationServices.Contracts
{
    public interface ICategoriaExternalServices
    {
        Task<string> BuscarCategoriaAsync(Guid id);
    }
}
