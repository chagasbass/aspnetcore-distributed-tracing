using MinimalApi.Extensions.Entities;
using MinimalApiDois.ApplicationServices.Dtos;

namespace MinimalApiDois.ApplicationServices.Contracts
{
    public interface ICategoriaApplicationServices
    {
        Task<CommandResult> BuscarCategoriaAsync(Guid id);
        Task<CommandResult> InserirCategoriaAsync(InserirCategoriaDto inserirCategoriaDto);

    }
}
