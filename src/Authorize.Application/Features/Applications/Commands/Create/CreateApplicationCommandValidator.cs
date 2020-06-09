using FluentValidation;
using FluentValidation.Results;

namespace Authorize.Application.Features.Applications.Commands.Create
{
    public class CreateApplicationCommandValidator : AbstractValidator<CreateApplicationCommand>
    {
        public CreateApplicationCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(v => v.Description)
                .MaximumLength(200);

            RuleFor(v => v.Permissions)
                .NotNull();
        }
        public override ValidationResult Validate(ValidationContext<CreateApplicationCommand> context)
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