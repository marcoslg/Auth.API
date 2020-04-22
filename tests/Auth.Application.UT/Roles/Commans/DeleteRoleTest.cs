using Auth.Application.Exceptions;
using Auth.Application.Roles.Commands.Delete;
using Auth.Application.UT.Common;
using Auth.Domain.Roles;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;
namespace Auth.Application.UT.Roles.Commans
{
    public class DeleteRoleTest : BaseTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_DeleteRole_InputInValid_ThrowValidationException(string roleName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<Unit>> act = async () =>
            {                
                var response = await mediator.Send(new DeleteRoleCommand()
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
        public async Task When_DeleteRole_InputIsValid_Return(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            var rolemanager = sp.GetService<RoleManager<Role>>();
            
            rolemanager.FindByNameAsync("").ReturnsForAnyArgs(new Role(roleName));
            rolemanager.DeleteAsync(null).ReturnsForAnyArgs(new TestIdentityResult(true));
            //Act
            var response = await mediator.Send(new DeleteRoleCommand()
            {
                Name = roleName
            });
            //Assert
            response.Should().NotBeNull();

        }

        [Theory]
        [InlineData("admin")]
        [InlineData("guest")]
        public async Task When_DeleteRole_InputIsValid_ThrowNotFoundException(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            var rolemanager = sp.GetService<RoleManager<Role>>();
            rolemanager.FindByNameAsync("").ReturnsForAnyArgs((Role)null);
            //Act
            Func<Task<Unit>> act = async () =>
            {                
                var response = await mediator.Send(new DeleteRoleCommand()
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
