using Auth.Application.Exceptions;
using Auth.Application.Roles.Commands.Create;
using Auth.Application.UT.Common;
using FluentAssertions;
using MediatR;
using System;
using System.Threading.Tasks;using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Auth.Application.Contracts;
using NSubstitute;

namespace Auth.Application.UT.Behaviours
{
    public class RequestAuthPreProcessorBehaviorTest : BaseTest
    {
        [Fact]
        public async Task When_CreateRole_UserInValid_ThrowForbidden()
        {
            //arrange
            var current = ServiceProvider.GetService<ICurrentUserService>();
            current.UserName.Returns("guest");

            //act
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<string>> act = async () =>
            {
                var response = await mediator.Send(new CreateRoleCommand()
                {
                    Name = "forbidden"
                });
                return response;
            };
            //assert
            act.Should().Throw<ForbiddenException>();
        }
    }
}
