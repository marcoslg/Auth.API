using Authorize.Application.Applications.Queries.Get.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Authorize.Application.Applications.Queries.Get
{
    public class GetApplicationQueryValidator : AbstractValidator<GetApplicationQuery>
    {
        public GetApplicationQueryValidator()
        {
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
        public override ValidationResult Validate(ValidationContext<GetApplicationQuery> context)
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