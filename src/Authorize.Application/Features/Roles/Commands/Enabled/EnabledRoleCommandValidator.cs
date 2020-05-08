using FluentValidation;
using FluentValidation.Results;

namespace Authorize.Application.Features.Roles.Commands.Enabled
{
    public class EnabledRoleCommandValidator : AbstractValidator<EnabledRoleCommand>
    {
        public EnabledRoleCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        public override ValidationResult Validate(ValidationContext<EnabledRoleCommand> context)
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
