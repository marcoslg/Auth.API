using Authorize.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authorize.Infrastructure.Persistence.EF
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructurePersitence(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase", false))
            {
                services.AddDbContext<AuthorizeDbContext>(options =>
                    options.UseInMemoryDatabase("AuthorizeDB"));
            }
            else if (configuration.GetValue<bool>("UseCosmos", false))
            {
                services.AddDbContext<AuthorizeDbContext>(options =>
                   options.UseCosmos(
                       configuration.GetConnectionString("DefaultConnection"),
                       configuration.GetConnectionString("CosmosKey"),
                       "AuthorizeDB"));
            }
            else
            {
                services.AddDbContext<AuthorizeDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(AuthorizeDbContext).Assembly.FullName)));
            }
            services.AddScoped<IAppDbContext, AuthorizeDbContext>(sp => sp.GetService<AuthorizeDbContext>());          

            return services;
        }
    }
}
