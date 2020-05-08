using Auth.Application.Exceptions;
using Auth.Application.Permisions.Common.Models;
using Auth.Application.Permisions.Queries.GetByApplication.Models;
using Auth.Application.UT.Common;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

namespace Auth.Application.UT.Permissions.Queries
{
    [ExcludeFromCodeCoverage]
    public class GetByApplicationTest : BaseTest
    {

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_ApplicationGetPermissionsQuery_InputInValid_ThrowValidationException(string name)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<IEnumerable<PermissionDto>>> act = async () =>
            {                
                var response = await mediator.Send(new GetPermissionsQuery()
                {
                    ApplicationName = name
                });
                return response;
            };
            act.Should().Throw<ValidationException>();

        }

        [Theory]        
        [InlineData(Constants.App)]
        public async Task When_ApplicationGetPermissionsQuery_InputIsValid_ReturnRoleVM(string name)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();
            //Act

            var response = await mediator.Send(new GetPermissionsQuery()
            {
                ApplicationName = name
            });

            //Assert
            response.Should().NotBeNull();

        }

        [Theory]
        [InlineData("admin1")]
        [InlineData("guest1")]
        public async Task When_ApplicationGetPermissionsQuery_InputIsValid_ThrowNotFoundException(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();

            //Act
            Func<Task<IEnumerable<PermissionDto>>> act = async () =>
            {                
                var response = await mediator.Send(new GetPermissionsQuery()
                {
                    ApplicationName = roleName
                });
                return response;
            };
            //Assert
            act.Should().Throw<NotFoundException>();

        }
    }
}
