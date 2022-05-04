using MinimalApiDois.ApplicationServices.Contracts;
using MinimalApiDois.ApplicationServices.Services;
using MinimalApiDois.Data.Repositories;
using MinimalApiDois.Domain.Repositories;

namespace MinimalApiDois.Extensions
{
    public static class MinimalApiDIExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaApplicationServices, CategoriaAplicationServices>();
            services.AddScoped<IMensagemExternalServices, MensagemExternalServices>();

            return services;
        }
    }
}
