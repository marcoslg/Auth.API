using FluentValidation;

namespace Auth.Application.Permisions.Queries.Get
{
    public class GetPermissionsQueryValidator : AbstractValidator<GetPermissionsQuery>
    {
        public GetPermissionsQueryValidator()
        {
            RuleFor(r => r.Username)
                .Transform( u=> u.ToLowerInvariant())
                .NotEmpty();

            RuleFor(r => r.ApplicationName)
                .Transform(u => u.ToLowerInvariant())
                .NotEmpty();
        }
    }
}
