using Auth.Application.Users.Queries.SearchRole.Models;
using Auth.Application.UT.Common;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace Auth.Application.UT.Users.Queries
{
    [ExcludeFromCodeCoverage]
    public class SearchUsersTest : BaseTest
    {
        [Theory]
        [InlineData("admin")]
        [InlineData("guest")]
        [InlineData("ad")]
        [InlineData("gu")]
        public async Task When_SearchRolesQuery_InputIsValid_ReturnList(string userName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            //Act

            var response = await mediator.Send(new SearchUsersQuery()
            {
                UserName = userName
            });
            //Assert
            response.Should().HaveCountGreaterOrEqualTo(1);

        }
    }
}
