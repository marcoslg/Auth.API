using Authorize.Application.Roles.Queries.SearchRole.Models;
using Authorize.Application.UT.Common;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace Authorize.Application.UT.Roles.Queries
{
    [ExcludeFromCodeCoverage]
    public class SearchRolesTest : BaseTest
    {
        [Theory]
        [InlineData("admi")]
        [InlineData("gues")]
        public async Task When_SearchRolesQuery_InputIsValid_ReturnList(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            //Act

            var response = await mediator.Send(new SearchRolesQuery()
            {
                Name = roleName
            });
            //Assert
            response.Should().HaveCountGreaterOrEqualTo(1);

        }
    }
}
