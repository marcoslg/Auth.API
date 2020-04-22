using Auth.Domain.Roles;
using Auth.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;

namespace Auth.Application.UT.Common
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMocks(this IServiceCollection service)
        => service
            .AddScoped<IRoleStore<Role>>(sp => Substitute.For<IRoleStore<Role>>())
            .AddScoped<IEnumerable<IRoleValidator<Role>>>(sp => Substitute.For<IEnumerable<IRoleValidator<Role>>>())
            .AddScoped<ILookupNormalizer>(sp => Substitute.For<ILookupNormalizer>())
            .AddScoped<IdentityErrorDescriber>(sp => Substitute.For<IdentityErrorDescriber>())
            .AddScoped<ILogger<RoleManager<Role>>>(sp => Substitute.For<ILogger<RoleManager<Role>>>())
            .AddScoped<RoleManager<Role>>(sp => Substitute.For<RoleManager<Role>>(sp.GetService< IRoleStore<Role>>(),
                sp.GetService<IEnumerable<IRoleValidator<Role>>>(),
                sp.GetService<ILookupNormalizer>(),
                sp.GetService<IdentityErrorDescriber>(),
                sp.GetService<ILogger<RoleManager<Role>>>()
                ))
            //user
            .AddScoped<IUserStore<User>>(sp => Substitute.For<IUserStore<User>>())
            .AddScoped<IPasswordHasher<User>>(sp => Substitute.For<IPasswordHasher<User>>())
            .AddScoped<IEnumerable<IUserValidator<User>>>(sp => Substitute.For<IEnumerable<IUserValidator<User>>>())
            .AddScoped<IEnumerable<IPasswordValidator<User>>>(sp => Substitute.For<IEnumerable<IPasswordValidator<User>>>())
            .AddScoped<ILogger<UserManager<User>>>(sp => Substitute.For<ILogger<UserManager<User>>>())
            .AddScoped<UserManager<User>>(sp =>
            Substitute.For<UserManager<User>>(sp.GetService<IUserStore<User>>(),
                sp.GetService<IPasswordHasher<User>>(),
                sp.GetService<IEnumerable<IUserValidator<User>>>(),
                sp.GetService<IEnumerable<IPasswordValidator<User>>>(),
                sp.GetService<ILookupNormalizer>(),
                sp.GetService<IdentityErrorDescriber>(),
                sp,
                sp.GetService<ILogger<UserManager<User>>>()
                ))
            ;

        /*
       IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor,
       IPasswordHasher<TUser> passwordHasher, 
       IEnumerable<IUserValidator<TUser>> userValidators,
       IEnumerable<IPasswordValidator<TUser>> passwordValidators,
       ILookupNormalizer keyNormalizer, 
       IdentityErrorDescriber errors,
       IServiceProvider services,
       ILogger<UserManager<TUser>> logger
         */
    }
}
