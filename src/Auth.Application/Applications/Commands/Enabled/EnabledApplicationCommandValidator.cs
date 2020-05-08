using FluentValidation;
using FluentValidation.Results;

namespace Auth.Application.Applications.Commands.Enabled
{
    public class EnabledRoleCommandValidator : AbstractValidator<EnabledApplicationCommand>
    {
        public EnabledRoleCommandValidator()
        {
            RuleFor(v => v.Name)                
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        public override ValidationResult Validate(ValidationContext<EnabledApplicationCommand> context)
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