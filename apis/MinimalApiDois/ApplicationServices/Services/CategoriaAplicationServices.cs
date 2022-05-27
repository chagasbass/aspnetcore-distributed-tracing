using MinimalApi.Extensions.Entities;
using MinimalApiDois.ApplicationServices.Bases;
using MinimalApiDois.ApplicationServices.Contracts;
using MinimalApiDois.ApplicationServices.Dtos;
using MinimalApiDois.Domain.Entities;
using MinimalApiDois.Domain.Repositories;
using System.Runtime.CompilerServices;

namespace MinimalApiDois.ApplicationServices.Services
{
    public class CategoriaAplicationServices : BaseApplicationServices<Categoria>, ICategoriaApplicationServices
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMensagemExternalServices _mensagemExternalServices;

        private const string _controllerName = "CategoriaController";

        public CategoriaAplicationServices(ICategoriaRepository categoriaRepository,
                                           IMensagemExternalServices mensagemExternalServices)
        {
            _categoriaRepository = categoriaRepository;
            _mensagemExternalServices = mensagemExternalServices;
        }

        public async Task<CommandResult> BuscarCategoriaAsync(Guid id)
        {
            var method = ExtensionHelper.GetActualAsyncMethodName();
            var dadosDeExecucao = $"{_controllerName}/{this.GetType().Name}/{method}";

            var activity = StartActivitySource(dadosDeExecucao);

            var categoriaEncontrada = await _categoriaRepository.BuscarCategoriaAsync(id);

            CommandResult commandResult;

            if (categoriaEncontrada is null)
            {
                commandResult = new CommandResult(false, "A categoria não foi encontrada");

                return AddActivityData(activity, id, commandResult);
            }

            await _mensagemExternalServices.EnviarMensagemAsync(new Mensagem { Conteudo = "Solicitação de categoria para produto" });

            commandResult = new CommandResult(categoriaEncontrada, true, "Categoria Encontrada");

            return AddActivityData(activity, categoriaEncontrada, commandResult);
        }

        public async Task<CommandResult> InserirCategoriaAsync(InserirCategoriaDto inserirCategoriaDto)
        {
            var method = ExtensionHelper.GetActualAsyncMethodName();
            var dadosDeExecucao = $"{_controllerName}/{this.GetType().Name}/{method}";

            var activity = StartActivitySource(dadosDeExecucao);

            var novaCategoria = new Categoria(inserirCategoriaDto.Nome);

            await _categoriaRepository.InserirCategoriaAsync(novaCategoria);

            await _mensagemExternalServices.EnviarMensagemAsync(new Mensagem { Conteudo = "Solicitação de  criação de categoria para produto" });

            var commandResult = new CommandResult(novaCategoria, true, "Categoria Cadastrada com sucesso");

            return AddActivityData(activity, novaCategoria, commandResult);
        }
    }

    public static class ExtensionHelper { public static string GetActualAsyncMethodName([CallerMemberName] string name = null) => name; }
}
