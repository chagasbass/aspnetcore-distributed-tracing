using MinimalApi.Extensions.Entities;
using MinimalApiUm.ApplicationServices.Dtos;

namespace MinimalApiUm.ApplicationServices.Contracts
{
    public interface IProdutoApplicationServices
    {
        Task<CommandResult> InserirProdutoAsync(InserirProdutoDto inserirProdutoDto);
    }
}
