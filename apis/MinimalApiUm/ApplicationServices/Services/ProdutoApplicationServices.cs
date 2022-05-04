using MinimalApi.Extensions.Entities;
using MinimalApiUm.ApplicationServices.Contracts;
using MinimalApiUm.ApplicationServices.Dtos;
using MinimalApiUm.Domain.Entities;
using MinimalApiUm.Domain.Repositories;

namespace MinimalApiUm.ApplicationServices.Services
{
    public class ProdutoApplicationServices : IProdutoApplicationServices
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaExternalServices _categoriaExternalServices;

        public ProdutoApplicationServices(IProdutoRepository produtoRepository,
                                          ICategoriaExternalServices categoriaExternalServices)
        {
            _produtoRepository = produtoRepository;
            _categoriaExternalServices = categoriaExternalServices;
        }

        public async Task<ICommandResult> InserirProdutoAsync(InserirProdutoDto inserirProdutoDto)
        {
            inserirProdutoDto.ValidarProduto();

            if (!inserirProdutoDto.IsValid)
                return new CommandResult(inserirProdutoDto.Notifications, false, "Problemas ao inserir o produto");

            var dadosCategoria = await _categoriaExternalServices.BuscarCategoriaAsync(inserirProdutoDto.CategoriaId);

            if (string.IsNullOrEmpty(dadosCategoria))
                return new CommandResult(false, "A categoria não existe");

            var novoProduto = new Produto(inserirProdutoDto.Nome, inserirProdutoDto.Preco, inserirProdutoDto.CategoriaId, dadosCategoria);

            await _produtoRepository.InserirProdutoAsync(novoProduto);

            return new CommandResult(novoProduto.Id, true, "Produto Inserido com sucesso");

        }
    }
}
