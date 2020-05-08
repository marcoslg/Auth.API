using Auth.Application.Roles.Queries.Get.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Auth.Application.Applications.Queries.Get
{
    public class GetApplicationQueryValidator : AbstractValidator<GetRoleQuery>
    {
        public GetApplicationQueryValidator()
        {
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        public override ValidationResult Validate(ValidationContext<GetRoleQuery> context)
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
