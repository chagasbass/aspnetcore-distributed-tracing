using Microsoft.EntityFrameworkCore;
using MinimalApiDois.Domain.Entities;
using System.Reflection;

namespace MinimalApiDois.Data.DataContext
{
    public class MinimalApiDataContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public MinimalApiDataContext(DbContextOptions<MinimalApiDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
