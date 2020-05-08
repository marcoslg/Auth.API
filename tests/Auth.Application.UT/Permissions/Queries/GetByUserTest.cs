using Auth.Application.Permisions.Common.Models;
using Auth.Application.UT.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Auth.Application.Permisions.Queries.GetByUser.Models;
using FluentValidation;
using FluentAssertions;
using Auth.Application.Exceptions;
using Auth.Application.UT.Permissions.DataProvaiders;
using Microsoft.EntityFrameworkCore;
using Auth.Domain.Users;
using System.Linq;

namespace Auth.Application.UT.Permissions.Queries
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
