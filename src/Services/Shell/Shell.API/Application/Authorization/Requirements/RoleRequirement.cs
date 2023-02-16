using Microsoft.AspNetCore.Authorization;

namespace Shell.API.Application.Authorization.Requirements
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public string[] Roles { get; }

        public RoleRequirement(params string[] roles)
        {
            Roles = roles;
        }
    }
}
