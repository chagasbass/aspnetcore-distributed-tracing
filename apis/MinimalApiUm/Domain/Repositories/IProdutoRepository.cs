using MinimalApiUm.Domain.Entities;

namespace MinimalApiUm.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> InserirProdutoAsync(Produto produto);
    }
}
