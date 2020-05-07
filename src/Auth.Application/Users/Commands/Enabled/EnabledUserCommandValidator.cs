using FluentValidation;
using FluentValidation.Results;

namespace Auth.Application.Users.Commands.Enabled
{
    public class EnabledUserCommandValidator : AbstractValidator<EnabledUserCommand>
    {
        public EnabledUserCommandValidator()
        {
            RuleFor(v => v.UserName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        public override ValidationResult Validate(ValidationContext<EnabledUserCommand> context)
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
