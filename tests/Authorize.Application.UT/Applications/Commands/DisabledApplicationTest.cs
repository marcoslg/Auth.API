using Authorize.Application.Exceptions;
using Authorize.Application.Features.Applications.Commands.Disabled;
using Authorize.Application.UT.Common;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace Authorize.Application.UT.Applications.Commands
{
    [ExcludeFromCodeCoverage]
    public class DisabledApplicationTest : BaseTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_DisabledApplication_InputInValid_ThrowValidationException(string applicationName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<Unit>> act = async () =>
            {                
                var response = await mediator.Send(new DisabledApplicationCommand()
                {
                    Name = applicationName
                });
                return response;
            };
            act.Should().Throw<ValidationException>();
        }

        //[Theory]
        //[InlineData(Constants.RoleAdmin)]
        //[InlineData(Constants.RoleGuest)]
        //public async Task When_DisabledApplication_InputIsValid_Return(string applicationName)
        //{
        //    using var scope = ServiceScopeProvider.CreateScope();
        //    var sp = scope.ServiceProvider;
        //    var mediator = sp.GetService<IMediator>();
        //    //var applicationmanager = sp.GetService<IAppDbContext>();
           
        //    //Act
        //    var response = await mediator.Send(new DisabledApplicationCommand()
        //    {
        //        Name = applicationName
        //    });
        //    //Assert
        //    response.Should().NotBeNull();
        //}

        [Theory]
        [InlineData(Constants.RoleAdmin + "1")]
        [InlineData(Constants.RoleGuest + "guest1")]
        public async Task When_DisabledApplication_InputIsValid_ThrowNotFoundException(string applicationName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();
            //Act
            Func<Task<Unit>> act = async () =>
            {                
                var response = await mediator.Send(new DisabledApplicationCommand()
                {
                    Name = applicationName
                });
                return response;
            };
            //Assert
            act.Should().Throw<NotFoundException>();
        }
    }
}