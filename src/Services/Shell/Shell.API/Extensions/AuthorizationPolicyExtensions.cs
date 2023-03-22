using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Shell.API.Application.Authorization;
using Shell.API.Application.Authorization.Requirements;
using Shell.API.Models.Constants;

namespace Shell.API.Extensions
{
    public static class AuthorizationPolicyExtensions
    {
        public static void AddAuthorizationPolicies(this AuthorizationOptions options)
        {
            options.AddPolicy(AuthorizationConstants.ComponentPolicy, policy =>
            {
                policy.AuthenticationSchemes = new[] { JwtBearerDefaults.AuthenticationScheme };
                policy.Requirements.Add(new RoleRequirement(nameof(Roles.Administrator)));
            });
        }
    }
}
