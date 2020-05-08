using FluentValidation;
using FluentValidation.Results;

namespace Auth.Application.Applications.Commands.Disabled
{
    public class DisabledApplicationCommandValidator : AbstractValidator<DisabledApplicationCommand>
    {
        public DisabledApplicationCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        
        public override ValidationResult Validate(ValidationContext<DisabledApplicationCommand> context)
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