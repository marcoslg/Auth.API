using Authorize.API.REST.Modules.Secutiry.ApiKeys.Contracts;
using Authorize.API.REST.Modules.Secutiry.ApiKeys.Extensions;
using Authorize.API.REST.Modules.Secutiry.ApiKeys.Services;
using Authorize.API.REST.Options;
using Authorize.API.REST.Services;
using Authorize.Application;
using Authorize.Application.Contracts;
using Authorize.Infrastructure.Persistence.EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authorize.API.REST.Start
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructurePersitence(Configuration);

            services.AddAuthorizeApplication();

            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<IGetApiKeyQuery, InMemoryGetApiKeyQuery>();

            var identityUrl = Configuration.GetValue<string>("IdentityUrl");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.Authority = Configuration["Jwt:Authority"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };

                })
             .AddApiKeySupport(options => { });



            services.AddHttpContextAccessor();
            services.AddControllers();




            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Authorize API";
                configure.AddSecurity("bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Flow = OpenApiOAuth2Flow.Implicit,
                    Description = "Authorization OAuth2 Service",
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            Scopes = new Dictionary<string, string>
                          {
                            { "read", "Read access to protected resources" },
                            { "write", "Write access to protected resources" }
                          },
                            AuthorizationUrl = "https://localhost:44333/oauth2service/secure/authorize",
                            TokenUrl = "https://localhost:44333/oauth2service/secure/token"
                        },
                    }
                });
                configure.AddSecurity("apiKey", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization apiKey",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("apiKey"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();
                SeedData.EnsureSeedData(app).GetAwaiter().GetResult();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
