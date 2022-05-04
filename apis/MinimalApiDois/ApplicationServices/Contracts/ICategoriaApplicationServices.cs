using MinimalApi.Extensions.Entities;

namespace MinimalApiDois.ApplicationServices.Contracts
{
    public interface ICategoriaApplicationServices
    {
        Task<CommandResult> BuscarCategoriaAsync(Guid id);
    }
}
