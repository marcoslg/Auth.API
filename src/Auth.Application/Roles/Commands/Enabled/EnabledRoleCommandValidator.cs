using FluentValidation;

namespace Auth.Application.Roles.Commands.Enabled
{
    public class EnabledRoleCommandValidator : AbstractValidator<EnabledRoleCommand>
    {
        public EnabledRoleCommandValidator()
        {
            RuleFor(v => v.Name)
                .Transform(u => u.ToLowerInvariant())
                .MaximumLength(200)
                .NotNull()
                .NotEmpty();
        }
    }
}
