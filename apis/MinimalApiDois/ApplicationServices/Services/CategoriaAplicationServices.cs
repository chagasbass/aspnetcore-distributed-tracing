using MinimalApi.Extensions.Entities;
using MinimalApiDois.ApplicationServices.Bases;
using MinimalApiDois.ApplicationServices.Contracts;
using MinimalApiDois.Domain.Repositories;

namespace MinimalApiDois.ApplicationServices.Services
{
    public class CategoriaAplicationServices : BaseApplicationServices, ICategoriaApplicationServices
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMensagemExternalServices _mensagemExternalServices;

        public CategoriaAplicationServices(ICategoriaRepository categoriaRepository,
                                           IMensagemExternalServices mensagemExternalServices)
        {
            _categoriaRepository = categoriaRepository;
            _mensagemExternalServices = mensagemExternalServices;
        }

        public async Task<CommandResult> BuscarCategoriaAsync(Guid id)
        {
            var categoriaEncontrada = await _categoriaRepository.BuscarCategoriaAsync(id);

            CommandResult commandResult;

            if (categoriaEncontrada is null)
            {
                commandResult = new CommandResult(false, "A categoria não foi encontrada");

                return AddActivityData(id, commandResult);
            }

            await _mensagemExternalServices.EnviarMensagemAsync("Solicitação de categoria para produto");

            commandResult = new CommandResult(categoriaEncontrada.Nome, true, "Categoria Encontrada");

            return AddActivityData(id, commandResult);
        }
    }
}
