using Authorize.Application.Exceptions;
using Authorize.Application.UT.Common;
using FluentAssertions;
using MediatR;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Authorize.Application.Contracts;
using NSubstitute;
using Authorize.Application.Features.Roles.Commands.Create;

namespace Authorize.Application.UT.Behaviours
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
