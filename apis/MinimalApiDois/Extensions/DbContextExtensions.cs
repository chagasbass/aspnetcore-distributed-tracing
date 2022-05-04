using Microsoft.EntityFrameworkCore;
using MinimalApiDois.Data.DataContext;

namespace MinimalApiDois.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContextInMemory(this IServiceCollection services)
        {
            services.AddDbContext<MinimalApiDataContext>(opt => opt.UseInMemoryDatabase("DbMinimalApiDois"));

            return services;
        }
    }
}
