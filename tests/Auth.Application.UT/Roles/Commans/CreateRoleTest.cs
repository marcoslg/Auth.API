using Auth.Application.Exceptions;
using Auth.Application.Roles.Commands.Create;
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
    public class CreateRoleTest : BaseTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_CreateRole_InputInValid_ThrowValidationException(string roleName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<string>> act = async () =>
            {                
                var response = await mediator.Send(new CreateRoleCommand()
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
        public async Task When_CreateRole_InputIsValid_Return(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            var rolemanager = sp.GetService<RoleManager<Role>>();
            rolemanager.FindByNameAsync("").ReturnsForAnyArgs((Role)null);
            rolemanager.CreateAsync(null).ReturnsForAnyArgs(new TestIdentityResult(true));
            //Act
            var response = await mediator.Send(new CreateRoleCommand()
            {
                Name = roleName
            });
            //Assert
            response.Should().NotBeNull();

        }

        [Theory]
        [InlineData("admin")]
        [InlineData("guest")]
        public async Task When_CreateRole_InputIsValid_ThrowExistsException(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            var rolemanager = sp.GetService<RoleManager<Role>>();            
            rolemanager.FindByNameAsync("").ReturnsForAnyArgs(new Role(roleName));
            //Act
            Func<Task<string>> act = async () =>
            {                
                var response = await mediator.Send(new CreateRoleCommand()
                {
                    Name = roleName
                });
                return response;
            };
            //Assert
            act.Should().Throw<ExistsException>();

        }
    }
}
