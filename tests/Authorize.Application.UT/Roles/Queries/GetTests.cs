using Authorize.Application.Exceptions;
using Authorize.Application.Features.Roles.Queries.Get.Models;
using Authorize.Application.Features.Roles.Queries.Models;
using Authorize.Application.UT.Common;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Authorize.Application.UT.Roles.Queries
{
    [ExcludeFromCodeCoverage]
    public class GetTests : BaseTest
    {

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sed tincidunt magna, ac consequat mauris. Praesent turpis augue, laoreet sed justo ut, efficitur euismod tortor. Ut laoreet nec ex nunc asdsdasdas das asdasdasdasdas")]
        public async Task When_GetRoleQuery_InputInValid_ThrowValidationException(string roleName)
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            Func<Task<RoleVM>> act = async () =>
            {
                var cancellationSourceToken = new CancellationTokenSource();
                var response = await mediator.Send(new GetRoleQuery()
                {
                    Name = roleName
                });
                return response;
            };
            act.Should().Throw<ValidationException>();

        }

        [Theory]
        [InlineData(Constants.RoleAdmin)]
        [InlineData(Constants.RoleGuest)]
        public async Task When_GetRoleQuery_InputIsValid_ReturnRoleVM(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();
            //Act

            var response = await mediator.Send(new GetRoleQuery()
            {
                Name = roleName
            });

            //Assert
            response.Should().NotBeNull();

        }

        [Theory]
        [InlineData("admin1")]
        [InlineData("guest1")]
        public async Task When_GetRoleQuery_InputIsValid_ThrowNotFoundException(string roleName)
        {
            using var scope = ServiceScopeProvider.CreateScope();
            var sp = scope.ServiceProvider;
            var mediator = sp.GetService<IMediator>();

            //Act
            Func<Task<RoleVM>> act = async () =>
            {
                var cancellationSourceToken = new CancellationTokenSource();
                var response = await mediator.Send(new GetRoleQuery()
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
