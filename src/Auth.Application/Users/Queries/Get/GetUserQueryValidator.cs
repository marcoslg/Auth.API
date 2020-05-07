using Auth.Application.Users.Queries.Get.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Auth.Application.Users.Queries.Get
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(r => r.UserName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        public override ValidationResult Validate(ValidationContext<GetUserQuery> context)
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
