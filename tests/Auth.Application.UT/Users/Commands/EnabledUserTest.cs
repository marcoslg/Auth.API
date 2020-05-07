using Auth.Application.Contracts;
using Auth.Application.Exceptions;
using Auth.Application.Users.Commands.Enabled;
using Auth.Application.UT.Common;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
namespace Auth.Application.UT.Users.Commans
{
    [ExcludeFromCodeCoverage]
    public class EnabledUserTest : BaseTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_EnabledUser_InputInValid_ThrowValidationException(string userName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<Unit>> act = async () =>
            {                
                var response = await mediator.Send(new EnabledUserCommand()
                {
                    UserName = userName
                });
                return response;
            };
            act.Should().Throw<ValidationException>();

        }

        [Theory]
        [InlineData("admin")]
        [InlineData("guest")]
        public async Task When_EnabledUser_InputIsValid_Return(string userName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            var rolemanager = sp.GetService<IAppDbContext>();
           
            //Act
            var response = await mediator.Send(new EnabledUserCommand()
            {
                UserName = userName
            });
            //Assert
            response.Should().NotBeNull();

        }

        [Theory]
        [InlineData("admin1")]
        [InlineData("guest1")]
        public async Task When_EnabledUser_InputIsValid_ThrowNotFoundException(string userName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();
            //Act
            Func<Task<Unit>> act = async () =>
            {                
                var response = await mediator.Send(new EnabledUserCommand()
                {
                    UserName = userName
                });
                return response;
            };
            //Assert
            act.Should().Throw<NotFoundException>();

        }
    }
}
