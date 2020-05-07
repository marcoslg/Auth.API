using Auth.Application.Contracts;
using Auth.Application.Extensions;
using Auth.Domain.Applications;
using Auth.Domain.Roles;
using Auth.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MockQueryable.NSubstitute;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace Auth.Application.UT.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMocks(this IServiceCollection service)
        {
            return service
            .AddSingleton<ICurrentUserService>(sp =>
            {
                var curs = Substitute.For<ICurrentUserService>();
                curs.UserName.Returns("unittesting");
                return curs;
            })
            .AddDBSetMocks<Auth.Domain.Applications.Application>(sp =>
            {
                var data = new List<Auth.Domain.Applications.Application>
                {
                    new Auth.Domain.Applications.Application("auth.application")
                };
                return data;
            })
            .AddDBSetMocks<User>(sp =>
            {
                var username = sp.GetService<ICurrentUserService>().UserName;
                var roles = sp.GetService<DbSet<Role>>();
                var data = new List<User>()
                {
                    new User(username, roles.ToList())
                };
                return data;
            })
            .AddDBSetMocks<Role>(sp =>
            {
                var applications = sp.GetService<DbSet<Auth.Domain.Applications.Application>>();
                var authPermisions = sp.GetService<IAuthPermisions>();
                var username = sp.GetService<ICurrentUserService>().UserName;

                var users = new List<User>()
                {
                    new User(username)
                };
                var data = new List<Role>()
                {
                    new Role("admin","admin desc", applications.Select(a => new ApplicationRole(){Application =a,Permisions=authPermisions.Permissions }))
                    { 
                        Users = users
                    },
                    new Role("guest","guest desc", applications.Select(a => new ApplicationRole(){Application =a,Permisions= new List<Permision>()
                    {
                        Permision.For(AuthPermisions.RoleGet),
                        Permision.For(AuthPermisions.RoleSearchrole),
                        Permision.For(AuthPermisions.UserGet),
                        Permision.For(AuthPermisions.UserSearchrole)
                    } }))
                };

                
                
                return data;
            })
            .AddScoped<IAppDbContext>(sp =>
            {
                var dbContext = Substitute.For<IAppDbContext>();
                var roles = sp.GetService<DbSet<Role>>();
                dbContext.Roles.Returns(roles);
                var users = sp.GetService<DbSet<User>>();
                dbContext.Users.Returns(users);
                var apps = sp.GetService<DbSet<Auth.Domain.Applications.Application>>();
                dbContext.Applications.Returns(apps);
                return dbContext;
            });
        }
        public static IServiceCollection AddDBSetMocks<T>(this IServiceCollection service, Func<IServiceProvider, IEnumerable<T>> fakeData)
                    where T : class
        {
            return service.AddScoped<DbSet<T>>(sp =>
            {
                var dataFake = fakeData(sp);
                var mock = dataFake.AsQueryable().BuildMockDbSet();
                return mock;
            });
        }
    }
}
