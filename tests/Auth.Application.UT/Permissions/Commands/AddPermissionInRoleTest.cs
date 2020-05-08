using Auth.Application.UT.Common;
using MediatR;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using Auth.Application.Permisions.Commands.AddPermissionInRole;
using FluentAssertions;
using System.Collections.Generic;
using FluentValidation;
using Auth.Application.Exceptions;
using Auth.Application.UT.Permissions.DataProvaiders;

namespace Auth.Application.UT.Permissions.Commands
{
    public class AddPermissionInRoleTest : BaseTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_AddPermissionRoleCommand_RoleNameNotValid_ThrowValidationException(string roleName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task> act = async () =>
            {
                await mediator.Send(new AddPermissionRoleCommand()
                {
                    RoleName = roleName
                });
            };
            act.Should().Throw<ValidationException>();
        }

        [Fact]
        public async Task When_AddPermissionRoleCommand_RoleNameValidPermissionsEmpty_ThrowValidationException()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task> act = async () =>
            {
                await mediator.Send(new AddPermissionRoleCommand()
                {
                    RoleName = "test"
                });
            };
            act.Should().Throw<ValidationException>();
        }

        [Theory]
        [ClassData(typeof(PermissionInvalidProvider))]
        public async Task When_AddPermissionRoleCommand_RoleNameValidPermissionsInvalid_ThrowValidationException(AddPermissionRoleCommand command)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task> act = async () =>
            {
                await mediator.Send(command);
            };
            act.Should().Throw<ValidationException>();
        }

        [Fact]
        public async Task When_AddPermissionRoleCommand_InputOk_ReturnOk()
        {
            var mediator = ServiceProvider.GetService<IMediator>();

           var result = await mediator.Send(new AddPermissionRoleCommand()
            {
                RoleName = "guest",
                Permisions = new Dictionary<string, IEnumerable<string>>()
                       {

                           {"auth.application", new List<string>()
                                {
                                    AuthPermisions.RoleGet,
                                    AuthPermisions.RoleSearch,
                                    AuthPermisions.UserGet,
                                    AuthPermisions.UserSearch
                                }
                           }
                       }
            });
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task When_AddPermissionRoleCommand_InputOk_ThrowNotFoundException()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
          
            Func<Task> act = async () =>
            {
                await mediator.Send(new AddPermissionRoleCommand()
                {
                    RoleName = "test",
                    Permisions = new Dictionary<string, IEnumerable<string>>()
                       {
                           {"auth.application", new List<string>()
                                {
                                    AuthPermisions.RoleGet,
                                    AuthPermisions.RoleSearch,
                                    AuthPermisions.UserGet,
                                    AuthPermisions.UserSearch
                                }
                           }
                       }
                });
            };
            act.Should().Throw<NotFoundException>();
        }
    }
}
