using Auth.Application.Roles.Queries.Get.Models;
using FluentValidation;

namespace Auth.Application.Roles.Queries.Get
{
    public class GetRoleQueryValidator : AbstractValidator<GetRoleQuery>
    {
        public GetRoleQueryValidator()
        {
            RuleFor(r => r.Name)
                .Transform(u => u.ToLowerInvariant())
                .MaximumLength(200)
                .NotNull()
                .NotEmpty();
        }
    }
}
