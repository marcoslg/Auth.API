using FluentValidation;
using FluentValidation.Results;

namespace Auth.Application.Users.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.UserName)
                .Transform(u => u.ToLowerInvariant())
                .MaximumLength(200)
                .NotNull()
                .NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<CreateUserCommand> context, ValidationResult result)
        {
            var validate = base.PreValidate(context, result);
            if (validate)
            {
                context.InstanceToValidate.UserName = context.InstanceToValidate.UserName.ToLowerInvariant();
            }
            return validate;
        }
    }
}
