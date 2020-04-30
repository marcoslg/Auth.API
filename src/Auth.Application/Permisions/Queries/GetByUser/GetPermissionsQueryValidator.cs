using Auth.Application.Permisions.Queries.GetByUser.Models;
using FluentValidation;

namespace Auth.Application.Permisions.Queries.GetByUser
{
    public class GetPermissionsQueryValidator : AbstractValidator<GetPermissionsQuery>
    {
        public GetPermissionsQueryValidator()
        {
            RuleFor(r => r.Username)
                .Transform(u => u.ToLowerInvariant())
                .NotEmpty();

            RuleFor(r => r.ApplicationName)
                .Transform(u => u.ToLowerInvariant())
                .NotEmpty();
        }
    }
}
