using Auth.Application.Permisions.Queries.GetByApplication.Models;
using FluentValidation;

namespace Auth.Application.Permisions.Queries.GetByApplication
{
    public class GetPermissionsQueryValidator : AbstractValidator<GetPermissionsQuery>
    {
        public GetPermissionsQueryValidator()
        {
            RuleFor(r => r.ApplicationName)
                .Transform(u => u.ToLowerInvariant())
                .NotEmpty();
        }
    }
}
