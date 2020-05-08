using FluentValidation;
using FluentValidation.Results;

namespace Authorize.Application.Features.Permisions.Commands.AddPermissionInRole
{
    public class AddPermissionRoleCommandValidator : AbstractValidator<AddPermissionRoleCommand>
    {
        public AddPermissionRoleCommandValidator()
        {
            RuleFor(v => v.RoleName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(v => v.Permisions)
                .NotNull()
                .NotEmpty();
        }
        public override ValidationResult Validate(ValidationContext<AddPermissionRoleCommand> context)
        {
            var validate = base.Validate(context);
            if (validate.IsValid)
            {
                context.InstanceToValidate.RoleName = context.InstanceToValidate.RoleName.ToLowerInvariant();
            }
            return validate;
        }
    }
}
