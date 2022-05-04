using MinimalApi.Data.DataContext;
using MinimalApiUm.Domain.Entities;
using MinimalApiUm.Domain.Repositories;

namespace MinimalApiUm.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MinimalApiDataContext _context;

        public ProdutoRepository(MinimalApiDataContext context)
        {
            _context = context;
        }

        public async Task<Produto> InserirProdutoAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;
        }
    }
}
