using Authorize.Application.UT.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentAssertions;
using Authorize.Application.Exceptions;
using Authorize.Application.UT.Permissions.DataProvaiders;
using Microsoft.EntityFrameworkCore;
using Authorize.Domain.Users;
using System.Linq;
using Authorize.Application.Features.Common.Models;
using Authorize.Application.Features.Permissions.Queries.GetByUser.Models;

namespace Authorize.Application.UT.Permissions.Queries
{
    [ExcludeFromCodeCoverage]
    public class GetByUserTest : BaseTest
    {
        [Theory]
        [ClassData(typeof(UserGetPermissionsQueryNoValidProvider))]
        public async Task When_UserGetPermissionsQuery_InputInValid_ThrowValidationException(GetPermissionsQuery query)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<IEnumerable<PermissionDto>>> act = async () =>
            {
                var response = await mediator.Send(query);
                return response;
            };
            act.Should().Throw<ValidationException>();

        }

        [Fact]
        public async Task When_UserGetPermissionsQueryy_InputIsValid_ReturnOk()
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();
            //Act

            var response = await mediator.Send(new GetPermissionsQuery()
            {
                ApplicationName = Constants.App,
                Username = Constants.UserAdmin,
            });

            //Assert
            response.Should().NotBeNull().And.HaveCountGreaterOrEqualTo(1);

        }

        [Fact]      
        public async Task When_UserGetPermissionsQuery_InputIsValid_ThrowDisabledException()
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var dbUsers = sp.GetService<DbSet<User>>();
            dbUsers.FirstOrDefault(u => u.UserName == Constants.UserAdmin).IsEnabled = false;
            var mediator = sp.GetService<IMediator>();

            //Act
            Func<Task<IEnumerable<PermissionDto>>> act = async () =>
            {
                var response = await mediator.Send(new GetPermissionsQuery()
                {
                    ApplicationName = Constants.App,
                    Username = Constants.UserAdmin,
                });
                return response;
            };
            //Assert
            act.Should().Throw<NotFoundException>();
        }
    }
}
