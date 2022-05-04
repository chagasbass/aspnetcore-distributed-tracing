using MinimalApi.Extensions.Entities;

namespace MinimalApi.Extensions.Shared
{
    public class ApiRolesConfigurationOptions
    {
        public const string ApiRolesConfig = "ApiRolesConfiguration";

        public List<MinimalApiRoles> Roles { get; set; }

        public ApiRolesConfigurationOptions()
        {
            Roles = new List<MinimalApiRoles>();
        }
    }
}
