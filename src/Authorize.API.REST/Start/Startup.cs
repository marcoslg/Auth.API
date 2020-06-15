using Authorize.API.REST.Constants;
using Authorize.API.REST.Filters;
using Authorize.API.REST.Modules.Secutiry.ApiKeys.Contracts;
using Authorize.API.REST.Modules.Secutiry.ApiKeys.Extensions;
using Authorize.API.REST.Modules.Secutiry.ApiKeys.Options;
using Authorize.API.REST.Modules.Secutiry.ApiKeys.Services;
using Authorize.API.REST.Options;
using Authorize.API.REST.Services;
using Authorize.Application;
using Authorize.Application.Contracts;
using Authorize.Infrastructure.Persistence.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    //options.SaveToken = true;
                    options.Authority = Configuration["Jwt:Authority"];      
                    
                    options.TokenValidationParameters = new TokenValidationParameters
                    { 
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = Configuration["Jwt:Audience"], //scope necesario de la api                      
                        ClockSkew = TimeSpan.Zero
                    };

                })
             .AddApiKeySupport(options => { });

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

            //}).AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            //{
            //    options.Authority = Configuration.GetValue<string>("OpenIdConnect:IdentityServerBaseUrl");
            //    options.RequireHttpsMetadata = Configuration.GetValue<bool>("OpenIdConnect:RequireHttpsMetadata", false);
            //    options.ClientId = Configuration.GetValue<string>("OpenIdConnect:ClientId");
            //    options.ClientSecret = Configuration.GetValue<string>("OpenIdConnect:ClientSecret");
            //    options.ResponseType = Configuration.GetValue<string>("OpenIdConnect:OidcResponseType", "code id_token"); 

            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        NameClaimType = Configuration.GetValue<string>("OpenIdConnect:TokenValidationClaimName", "name")
            //    };
            //})
            // .AddApiKeySupport(options => { });



            services.AddHttpContextAccessor();
                       
            services.AddControllers(options =>
                options.Filters.Add(new ApiExceptionFilter()));


            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Authorize API";
                configure.AddSecurity(OpenIdConnectDefaults.AuthenticationScheme, Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Name = "Authorization OpenIdConnect",
                    Flow = OpenApiOAuth2Flow.Implicit,
                    Description = "Authorization OpenIdConnect Service",
                    Flows = new OpenApiOAuthFlows()
                    {

                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = $"{Configuration.GetValue<string>("OpenIdConnect:IdentityServerBaseUrl")}/connect/authorize",
                            Scopes = new Dictionary<string, string> {
                                { "authorize.application", "Authorize API" }
                            }
                            //TokenUrl = $"{Configuration.GetValue<string>("OpenIdConnect:IdentityServerBaseUrl")}/connect/token"
                        },
                    }
                });
                configure.AddSecurity(ApiKeyAuthenticationOptions.DefaultScheme, Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization apiKey",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: {Apikey} ."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor(OpenIdConnectDefaults.AuthenticationScheme));
                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor(ApiKeyAuthenticationOptions.DefaultScheme));
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
            app.UseOpenApi();
            app.UseSwaggerUi3(s => {
                s.OAuth2Client = new NSwag.AspNetCore.OAuth2ClientSettings()
                {
                    ClientId = $"{Configuration.GetValue<string>("OpenIdConnect:ClientId")}_swagger",
                    //ClientSecret = Configuration.GetValue<string>("OpenIdConnect:ClientSecret"),                   
                };

                });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }

        //public static void AddAuthentication(this IServiceCollection services, AuthOptions authOptions)
        //{
        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultScheme = OpenIdConnectDefaults.AuthenticationScheme;
        //       // options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

        //        //options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //        //options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //        //options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //        //options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //    })
                   
        //            .AddOpenIdConnect(AuthenticationConsts.OidcAuthenticationScheme, options =>
        //            {
        //                options.Authority = authOptions.IdentityServerBaseUrl;
        //                options.RequireHttpsMetadata = authOptions.RequireHttpsMetadata;
        //                options.ClientId = authOptions.ClientId;
        //                options.ClientSecret = authOptions.ClientSecret;
        //                options.ResponseType = authOptions.OidcResponseType;

        //                options.TokenValidationParameters = new TokenValidationParameters
        //                {
        //                    NameClaimType = authOptions.TokenValidationClaimName
        //                };                       
        //            });
        //}
    }
}
