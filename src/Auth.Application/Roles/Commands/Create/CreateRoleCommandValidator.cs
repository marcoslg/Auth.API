using FluentValidation;
using FluentValidation.Results;

namespace Auth.Application.Roles.Commands.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        public override ValidationResult Validate(ValidationContext<CreateRoleCommand> context)
        {
            var validate = base.Validate(context);
            if (validate.IsValid)
            {
                context.InstanceToValidate.Name = context.InstanceToValidate.Name.ToLowerInvariant();
            }
            return validate;
        }
    }
}
