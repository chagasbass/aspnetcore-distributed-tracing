using MinimalApiUm.ApplicationServices.Contracts;
using MinimalApiUm.ApplicationServices.Services;
using MinimalApiUm.Data.Repositories;
using MinimalApiUm.Domain.Repositories;

namespace MinimalApiUm.Extensions
{
    public static class MinimalApiDIExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoApplicationServices, ProdutoApplicationServices>();
            services.AddScoped<ICategoriaExternalServices, CategoriaExternalServices>();

            return services;
        }
    }
}
