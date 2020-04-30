using FluentValidation;

namespace Auth.Application.Roles.Commands.Delete
{
    public class DisabledRoleCommandValidator : AbstractValidator<DisabledRoleCommand>
    {
        public DisabledRoleCommandValidator()
        {
            RuleFor(v => v.Name)
                .Transform(u => u.ToLowerInvariant())
                .MaximumLength(200)
                .NotNull()
                .NotEmpty();
        }
    }
}
