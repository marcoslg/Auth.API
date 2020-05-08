using FluentValidation;
using FluentValidation.Results;

namespace Authorize.Application.Applications.Commands.Enabled
{
    public class EnabledApplicationCommandValidator : AbstractValidator<EnabledApplicationCommand>
    {
        public EnabledApplicationCommandValidator()
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