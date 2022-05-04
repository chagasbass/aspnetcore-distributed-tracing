namespace MinimalApiDois.Extensions
{
    public static class ExternalServicesExtensions
    {
        public static IServiceCollection AddHttpClientResilience(this IServiceCollection services)
        {
            services.AddHttpClient("minimal-api")
                    .SetHandlerLifetime(TimeSpan.FromMinutes(5));

            return services;
        }
    }
}
