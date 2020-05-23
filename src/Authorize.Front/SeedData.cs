using Authorize.Application;
using Authorize.Application.Contracts;
using Authorize.Infrastructure.Persistence.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorize.Front
{
    public static class SeedData
    {
        public static async Task EnsureSeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<AuthorizeDbContext>();
                var authPermisions = serviceScope.ServiceProvider.GetRequiredService<IAuthPermisions>();
                AuthorizeDbContextSeed.SeedDefaultAsync(dbContext, authPermisions);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
