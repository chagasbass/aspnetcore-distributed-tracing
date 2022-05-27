using MinimalApi.Extensions.Entities;
using MinimalApiUm.ApplicationServices.Dtos;

namespace MinimalApiUm.ApplicationServices.Contracts
{
    public interface ICategoriaExternalServices
    {
        Task<CommandResult> BuscarCategoriaAsync(Guid id);
        Task<CommandResult> InserirCategoriaAsync(InserirCategoriaDto inserirCategoriaDto);
    }
}
