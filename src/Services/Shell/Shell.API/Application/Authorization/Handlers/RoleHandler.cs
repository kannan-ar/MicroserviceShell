using Microsoft.AspNetCore.Authorization;
using Shell.API.Application.Authorization.Requirements;
using System.Linq;
using System.Threading.Tasks;

namespace Shell.API.Application.Authorization.Handlers
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if(!requirement.Roles.Any(role => !context.User.IsInRole(role)))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
