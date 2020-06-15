using Authorize.Application;
using Authorize.Application.Contracts;
using Authorize.Infrastructure.Persistence.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorize.API.REST.Start
{
    public static class SeedData
    {
        public static async Task EnsureSeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<AuthorizeDbContext>();
                var authPermissions = serviceScope.ServiceProvider.GetRequiredService<IAuthPermissions>();
                AuthorizeDbContextSeed.SeedDefaultAsync(dbContext, authPermissions);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
