using Auth.Application.Exceptions;
using Auth.Application.Roles.Queries.Get.Models;
using Auth.Application.UT.Common;
using Auth.Domain.Roles;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Auth.Application.UT.Roles.Queries
{
    public class GetTests : BaseTest
    {

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_GetQuery_InputInValid_ThrowValidationException(string roleName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<RoleVM>> act = async () =>
            {
                var cancellationSourceToken = new CancellationTokenSource();
                var response = await mediator.Send(new GetRoleQuery()
                {
                    Name = roleName
                });
                return response;
            };
            act.Should().Throw<ValidationException>();

        }

        [Theory]
        [InlineData("admin")]
        [InlineData("guest")]
        public async Task When_GetQuery_InputIsValid_ReturnRoleVM(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            var rolemanager = sp.GetService<RoleManager<Role>>();
            rolemanager.FindByNameAsync("").ReturnsForAnyArgs(new Role(roleName));

            //Act

            var response = await mediator.Send(new GetRoleQuery()
            {
                Name = roleName
            });

            //Assert
            response.Should().NotBeNull();

        }

        [Theory]
        [InlineData("admin")]
        [InlineData("guest")]
        public async Task When_GetQuery_InputIsValid_ThrowNotFoundException(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            var rolemanager = sp.GetService<RoleManager<Role>>();
            rolemanager.FindByNameAsync("").Returns((Role)null);

            //Act
            Func<Task<RoleVM>> act = async () =>
            {
                var cancellationSourceToken = new CancellationTokenSource();
                var response = await mediator.Send(new GetRoleQuery()
                {
                    Name = roleName
                });
                return response;
            };
            //Assert
            act.Should().Throw<NotFoundException>();

        }
    }
}
