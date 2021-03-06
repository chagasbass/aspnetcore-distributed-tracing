using Microsoft.EntityFrameworkCore;
using MinimalApiUm.Data.DataContext;

namespace MinimalApiUm.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContextInMemory(this IServiceCollection services)
        {
            services.AddDbContext<MinimalApiDataContext>(opt => opt.UseInMemoryDatabase("DbMinimalApiUm"));

            return services;
        }
    }
}
