using Authorize.Application.Exceptions;
using Authorize.Application.Users.Commands.Create;
using Authorize.Application.UT.Common;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace Authorize.Application.UT.Users.Commans
{
    [ExcludeFromCodeCoverage]
    public class CreateUserTest : BaseTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_CreateUser_InputInValid_ThrowValidationException(string userName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<string>> act = async () =>
            {                
                var response = await mediator.Send(new CreateUserCommand()
                {
                    UserName = userName
                });
                return response;
            };
            act.Should().Throw<ValidationException>();

        }

        [Theory]
        [InlineData(Constants.UserAdmin + "_test")]
        [InlineData(Constants.UserGuest  +"_test")]
        public async Task When_CreateUser_InputIsValid_Return(string userName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();           
            //Act
            var response = await mediator.Send(new CreateUserCommand()
            {
                UserName = userName
            });
            //Assert
            response.Should().NotBeNull();

        }

        [Theory]
        [InlineData(Constants.UserAdmin)]
        [InlineData(Constants.UserGuest)]
        public async Task When_CreateUser_InputIsValid_ThrowExistsException(string userName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;

            var mediator = sp.GetService<IMediator>();
            //Act
            Func<Task<string>> act = async () =>
            {                
                var response = await mediator.Send(new CreateUserCommand()
                {
                    UserName = userName
                });
                return response;
            };
            //Assert
            act.Should().Throw<ExistsException>();

        }
    }
}
