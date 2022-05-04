using MinimalApi.Extensions.Entities;
using MinimalApiUm.ApplicationServices.Dtos;

namespace MinimalApiUm.ApplicationServices.Contracts
{
    public interface IProdutoApplicationServices
    {
        Task<ICommandResult> InserirProdutoAsync(InserirProdutoDto inserirProdutoDto);
    }
}
