using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Extensions.Shared;
using MinimalApi.Shared;

namespace MinimalApi.Extensions
{
    public static class OptionsExtensions
    {
        public static IServiceCollection AddBaseConfigurationOptionsPattern(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BaseConfigurationOptions>(configuration.GetSection(BaseConfigurationOptions.BaseConfig));
            services.Configure<ApiRolesConfigurationOptions>(configuration.GetSection(ApiRolesConfigurationOptions.ApiRolesConfig));
            services.Configure<JaeggerConfigurationOptions>(configuration.GetSection(JaeggerConfigurationOptions.JaeggerConfig));

            return services;
        }
    }
}
