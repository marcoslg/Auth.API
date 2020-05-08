using Authorize.Application.Features.Permisions.Queries.GetByApplication.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Authorize.Application.Features.Permisions.Queries.GetByApplication
{
    public class GetPermissionsQueryValidator : AbstractValidator<GetPermissionsQuery>
    {
        public GetPermissionsQueryValidator()
        {
            RuleFor(r => r.ApplicationName)
                .NotEmpty()
                .MaximumLength(200);
        }

        public override ValidationResult Validate(ValidationContext<GetPermissionsQuery> context)
        {
            var validate = base.Validate(context);
            if (validate.IsValid)
            {
                context.InstanceToValidate.ApplicationName = context.InstanceToValidate.ApplicationName.ToLowerInvariant();
            }
            return validate;
        }
    }
}
