using FluentValidation;

namespace Auth.Application.Permisions.Queries.Get
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
    }
}
