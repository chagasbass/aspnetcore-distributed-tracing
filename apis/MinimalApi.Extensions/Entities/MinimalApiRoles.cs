namespace MinimalApi.Extensions.Entities
{
    public class MinimalApiRoles
    {
        public string? RoleName { get; set; }
        public string? RoleAlias { get; set; }

        public MinimalApiRoles(string? roleName, string? roleAlias)
        {
            RoleName = roleName;
            RoleAlias = roleAlias;
        }
    }
}
