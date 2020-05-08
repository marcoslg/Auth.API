using FluentValidation;
using FluentValidation.Results;

namespace Authorize.Application.Users.Commands.Disabled
{
    public class DisabledUserCommandValidator : AbstractValidator<DisabledUserCommand>
    {
        public DisabledUserCommandValidator()
        {
            RuleFor(v => v.UserName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }

        public override ValidationResult Validate(ValidationContext<DisabledUserCommand> context)
        {
            var validate = base.Validate(context);
            if (validate.IsValid)
            {
                context.InstanceToValidate.UserName = context.InstanceToValidate.UserName.ToLowerInvariant();
            }
            return validate;
        }
    }
}
