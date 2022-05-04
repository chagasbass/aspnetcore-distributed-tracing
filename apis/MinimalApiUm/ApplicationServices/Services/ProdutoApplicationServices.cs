using MinimalApi.Extensions.Entities;
using MinimalApiUm.ApplicationServices.Bases;
using MinimalApiUm.ApplicationServices.Contracts;
using MinimalApiUm.ApplicationServices.Dtos;
using MinimalApiUm.Domain.Entities;
using MinimalApiUm.Domain.Repositories;

namespace MinimalApiUm.ApplicationServices.Services
{
    public class ProdutoApplicationServices : BaseApplicationServices, IProdutoApplicationServices
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
            StartActivitySource();

            inserirProdutoDto.ValidarProduto();

            CommandResult commandResult;

            if (!inserirProdutoDto.IsValid)
            {
                commandResult = new CommandResult(inserirProdutoDto.Notifications, false, "Problemas ao inserir o produto");

                return AddActivityData(inserirProdutoDto, commandResult);
            }

            var dadosCategoria = await _categoriaExternalServices.BuscarCategoriaAsync(inserirProdutoDto.CategoriaId);

            if (!dadosCategoria.Success)
            {
                commandResult = new CommandResult(false, dadosCategoria.Message);

                return AddActivityData(inserirProdutoDto, commandResult);
            }

            var novoProduto = new Produto(inserirProdutoDto.Nome, inserirProdutoDto.Preco, inserirProdutoDto.CategoriaId, (string)dadosCategoria.Data);

            await _produtoRepository.InserirProdutoAsync(novoProduto);

            commandResult = new CommandResult(novoProduto.Id, true, "Produto Inserido com sucesso");

            return AddActivityData(inserirProdutoDto, commandResult);
        }
    }
}
