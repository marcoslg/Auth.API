using Auth.Application.Roles.Queries.SearchRole.Models;
using Auth.Application.UT.Common;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Auth.Application.UT.Roles.Queries
{
    public class SearchRolesTest : BaseTest
    {
        [Theory]
        [InlineData("admin")]
        [InlineData("guest")]
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
