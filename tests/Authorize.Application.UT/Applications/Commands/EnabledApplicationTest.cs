﻿using Authorize.Application.Exceptions;
using Authorize.Application.Features.Applications.Commands.Enabled;
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
    public class EnabledApplicationTest : BaseTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_EnabledApplication_InputInValid_ThrowValidationException(string applicationName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<Unit>> act = async () =>
            {
                var response = await mediator.Send(new EnabledApplicationCommand()
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
        //public async Task When_EnabledApplication_InputIsValid_Return(string roleName)
        //{
        //    using var scope = ServiceScopeProvider.CreateScope();
        //    var sp = scope.ServiceProvider;

        //    var mediator = sp.GetService<IMediator>();
        //    //var rolemanager = sp.GetService<IAppDbContext>();

        //    //Act
        //    var response = await mediator.Send(new EnabledApplicationCommand()
        //    {
        //        Name = roleName
        //    });
        //    //Assert
        //    response.Should().NotBeNull();

        //}

        [Theory]
        [InlineData(Constants.RoleAdmin + "1")]
        [InlineData(Constants.RoleGuest + "guest1")]
        public async Task When_EnabledApplication_InputIsValid_ThrowNotFoundException(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();
            //Act
            Func<Task<Unit>> act = async () =>
            {
                var response = await mediator.Send(new EnabledApplicationCommand()
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