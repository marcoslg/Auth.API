using FluentValidation;
using FluentValidation.Results;

namespace Authorize.Application.Roles.Commands.Disabled
{
    public class DisabledRoleCommandValidator : AbstractValidator<DisabledRoleCommand>
    {
        public DisabledRoleCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        
        public override ValidationResult Validate(ValidationContext<DisabledRoleCommand> context)
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
