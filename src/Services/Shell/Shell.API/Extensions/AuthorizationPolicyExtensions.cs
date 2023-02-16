using Microsoft.AspNetCore.Authorization;
using Shell.API.Application.Authorization;
using Shell.API.Application.Authorization.Requirements;

namespace Shell.API.Extensions
{
    public static class AuthorizationPolicyExtensions
    {
        public static void AddAuthorizationPolicies(this AuthorizationOptions options)
        {
            options.AddPolicy("ComponentPolicy", policy =>
            {
                policy.Requirements.Add(new RoleRequirement(nameof(Roles.Administrator)));
            });
        }
    }
}
