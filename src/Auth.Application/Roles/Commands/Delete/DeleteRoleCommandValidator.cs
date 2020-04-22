using FluentValidation;

namespace Auth.Application.Roles.Commands.Delete
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotNull()
                .NotEmpty();
        }
    }
}
