using Microsoft.EntityFrameworkCore;
using MinimalApiDois.Data.DataContext;
using MinimalApiDois.Domain.Entities;
using MinimalApiDois.Domain.Repositories;

namespace MinimalApiDois.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MinimalApiDataContext _context;

        public CategoriaRepository(MinimalApiDataContext context)
        {
            _context = context;
        }
        public async Task<Categoria> BuscarCategoriaAsync(Guid id)
        {
            return await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Categoria> InserirCategoriaAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }
    }
}
