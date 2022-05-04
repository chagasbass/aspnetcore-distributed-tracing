using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using MinimalApiUm.Domain.Entities;
using System.Reflection;

namespace MinimalApi.Data.DataContext
{
    public class MinimalApiDataContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public MinimalApiDataContext(DbContextOptions<MinimalApiDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Ignore<Notification>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
