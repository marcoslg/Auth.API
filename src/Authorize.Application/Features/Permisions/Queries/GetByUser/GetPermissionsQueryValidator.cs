using Authorize.Application.Features.Permisions.Queries.GetByUser.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Authorize.Application.Features.Permisions.Queries.GetByUser
{
    public class GetPermissionsQueryValidator : AbstractValidator<GetPermissionsQuery>
    {
        public GetPermissionsQueryValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty();

            RuleFor(r => r.ApplicationName)
                .NotEmpty();
        }
        public override ValidationResult Validate(ValidationContext<GetPermissionsQuery> context)
        {
            var validate = base.Validate(context);
            if (validate.IsValid)
            {
                context.InstanceToValidate.ApplicationName = context.InstanceToValidate.ApplicationName.ToLowerInvariant();
                context.InstanceToValidate.Username = context.InstanceToValidate.Username.ToLowerInvariant();
            }
            return validate;
        }
    }
}
