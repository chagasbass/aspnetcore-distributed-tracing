using MinimalApi.Extensions.Entities;
using MinimalApiUm.ApplicationServices.Bases;
using MinimalApiUm.ApplicationServices.Contracts;
using MinimalApiUm.ApplicationServices.Dtos;
using MinimalApiUm.Domain.Entities;
using MinimalApiUm.Domain.Repositories;
using System.Runtime.CompilerServices;

namespace MinimalApiUm.ApplicationServices.Services
{
    public class ProdutoApplicationServices : BaseApplicationServices<InserirProdutoDto>, IProdutoApplicationServices
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaExternalServices _categoriaExternalServices;

        private const string _controllerName = "ProdutoController";

        public ProdutoApplicationServices(IProdutoRepository produtoRepository,
                                          ICategoriaExternalServices categoriaExternalServices)
        {
            _produtoRepository = produtoRepository;
            _categoriaExternalServices = categoriaExternalServices;
        }

        public async Task<CommandResult> InserirProdutoAsync(InserirProdutoDto inserirProdutoDto)
        {
            var method = ExtensionHelper.GetActualAsyncMethodName();
            var dadosDeExecucao = $"{_controllerName}/{this.GetType().Name}/{method}";

            var activity = StartActivitySource(dadosDeExecucao);

            inserirProdutoDto.ValidarProduto();

            if (!inserirProdutoDto.IsValid)
            {
                var _errorCommandResult = new CommandResult(inserirProdutoDto.Notifications, false, "Problemas ao inserir o produto");

                AddActivityData(activity, inserirProdutoDto, _errorCommandResult);
                return _errorCommandResult;
            }

            var dadosCategoria = await _categoriaExternalServices.BuscarCategoriaAsync(inserirProdutoDto.CategoriaId);

            Categoria novaCategoria = null;

            if (!dadosCategoria.Success)
            {
                var categoriaResultado = await _categoriaExternalServices.InserirCategoriaAsync(new InserirCategoriaDto { Nome = inserirProdutoDto.NomeCategoria });

                novaCategoria = RecuperarDadosDeCategoria(categoriaResultado);
            }

            var novoProduto = new Produto(inserirProdutoDto.Nome, inserirProdutoDto.Preco, inserirProdutoDto.CategoriaId, novaCategoria.Nome);

            await _produtoRepository.InserirProdutoAsync(novoProduto);

            var commandResult = new CommandResult(novoProduto.Id, true, "Produto Inserido com sucesso");

            AddActivityData(activity, inserirProdutoDto, commandResult);

            return commandResult;
        }
    }

    public static class ExtensionHelper { public static string GetActualAsyncMethodName([CallerMemberName] string name = null) => name; }
}
