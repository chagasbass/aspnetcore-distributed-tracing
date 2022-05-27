using MinimalApiDois.Domain.Entities;

namespace MinimalApiDois.Domain.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> BuscarCategoriaAsync(Guid id);
        Task<Categoria> InserirCategoriaAsync(Categoria categoria);
    }
}
