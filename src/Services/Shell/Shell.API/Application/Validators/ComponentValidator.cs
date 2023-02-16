using FluentValidation;
using MongoDB.Driver;
using Shell.API.Domain.Services;
using Shell.API.Models.DTOs;

namespace Shell.API.Application.Validators
{
    public class ComponentValidator: AbstractValidator<Component>
    {
        public ComponentValidator(IComponentService componentService)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage($"{nameof(Component.Name)} should not be empty")
                .MustAsync(async (component, token, context) =>
                {
                    return !await componentService.IsComponentExistsAsync(component.Name);
                })
                .WithMessage(component => $"{component.Name} already exists");

            RuleFor(x => x.RemoteName)
                .NotEmpty()
                .WithMessage($"{nameof(Component.RemoteName)} should not be empty");

            RuleFor(x => x.RemoteEndpoint)
                .NotEmpty()
                .WithMessage($"{nameof(Component.RemoteEndpoint)} should not be empty");

            RuleFor(x => x.ComponentName)
                .NotEmpty()
                .WithMessage($"{nameof(Component.RemoteEndpoint)} should not be empty");
        }
    }
}
