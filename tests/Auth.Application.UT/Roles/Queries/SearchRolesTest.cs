using Auth.Application.Roles.Queries.SearchRole.Models;
using Auth.Application.UT.Common;
using Auth.Domain.Roles;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
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
            var rolemanager = sp.GetService<RoleManager<Role>>();
            var data = new TestAsyncEnumerable<Role>( new List<Role>() {
                new Role("admin"),
                new Role("guest"),
                new Role("administration")
            }).AsQueryable();
            rolemanager.Roles.Returns(data);
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
