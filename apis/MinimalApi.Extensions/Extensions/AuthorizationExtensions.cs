using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Extensions.Entities;

namespace MinimalApi.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddMinimalApiAuthorization(this IServiceCollection services, List<MinimalApiRoles> minimalApiRoles)
        {
            if (minimalApiRoles.Any())
            {
                services.AddAuthorization(options =>
                {
                    minimalApiRoles.ForEach(minimalApiRole =>
                    {
                        options.AddPolicy(name: minimalApiRole.RoleName, configurePolicy: policy => policy.RequireRole(roles: minimalApiRole.RoleAlias));
                    });
                });
            }
            else
            {
                services.AddAuthorization(options =>
                {
                    options.AddPolicy(name: "Admin", configurePolicy: policy => policy.RequireRole(roles: "admin"));
                    options.AddPolicy(name: "User", configurePolicy: policy => policy.RequireRole(roles: "user"));

                });
            }

            return services;
        }
    }
}

