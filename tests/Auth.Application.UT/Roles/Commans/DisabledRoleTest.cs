using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Application.Roles.Commands.Delete;
using Auth.Application.UT.Common;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
namespace Auth.Application.UT.Roles.Commans
{
    [ExcludeFromCodeCoverage]
    public class DisabledRoleTest : BaseTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_DisabledRole_InputInValid_ThrowValidationException(string roleName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<Unit>> act = async () =>
            {                
                var response = await mediator.Send(new DisabledRoleCommand()
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
        public async Task When_DisabledRole_InputIsValid_Return(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            var rolemanager = sp.GetService<IAppDbContext>();
           
            //Act
            var response = await mediator.Send(new DisabledRoleCommand()
            {
                Name = roleName
            });
            //Assert
            response.Should().NotBeNull();

        }

        [Theory]
        [InlineData("admin1")]
        [InlineData("guest1")]
        public async Task When_DisabledRole_InputIsValid_ThrowNotFoundException(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();
            //Act
            Func<Task<Unit>> act = async () =>
            {                
                var response = await mediator.Send(new DisabledRoleCommand()
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
