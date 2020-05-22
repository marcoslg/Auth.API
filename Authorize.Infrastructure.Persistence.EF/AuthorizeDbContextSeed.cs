using Authorize.Application;
using Authorize.Application.Contracts;
using Authorize.Domain.Roles;
using Authorize.Domain.Users;
using System.Linq;

namespace Authorize.Infrastructure.Persistence.EF
{
    public static class AuthorizeDbContextSeed
    {       

        public static void SeedDefaultAsync(IAppDbContext context, IAuthPermisions authPermisions)
        {
            var appAuth = SeedApplication(context, authPermisions);
            var defaultRole = new Role("admin", "admin");
            var defaultUser = new User("admin");

            defaultRole.Applications.Add(new ApplicationRole()
            {
                Application = appAuth,
                Permisions = appAuth.Permisions

            });
            defaultRole.Users.Add(new Domain.Relations.UserRole()
            {
                User = defaultUser,
                Role = defaultRole
            });


            context.Users.Add(defaultUser);
            context.Roles.Add(defaultRole);

        }

        public static Authorize.Domain.Applications.Application SeedApplication(IAppDbContext context, IAuthPermisions authPermisions)
        {
            var app = new Authorize.Domain.Applications.Application("authorize.application")
            {
                Permisions = authPermisions.Permissions.ToList()
            };
            context.Applications.Add(app);
            return app;
        }       
    }
}
