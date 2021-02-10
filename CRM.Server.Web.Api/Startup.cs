using AutoMapper;
using CRM.Server.Data;
using CRM.Server.Models;
using CRM.Server.Services.Identity;
using CRM.Server.Web.Api.Core.Security.Hashing;
using CRM.Server.Web.Api.Core.Security.Tokens;
using CRM.Server.Web.Api.Core.Services;
using CRM.Server.Web.Api.Configurations;
using CRM.Server.Web.Api.Security.Hashing;
using CRM.Server.Web.Api.Security.Tokens;
using CRM.Server.Web.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using CRM.Server.Web.Api.Security;
using CRM.Server.Web.Api.Core.JsonConverters;
using CRM.Server.Services;
using CRM.Server.Web.Api.Core.Helpers;
using CRM.Server.Data.Identity;
using CRM.Server.Web.Api.Extensions;

namespace CRM.Server.Web.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
               builder.SetIsOriginAllowed(_ => true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

                options.AddPolicy("CorsPolicy",
                    builder => builder
                        //.SetIsOriginAllowed(_ => true)
                        //.SetIsOriginAllowedToAllowWildcardSubdomains()
                        //.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                .SetIsOriginAllowed((host) => true)
                        .AllowCredentials()
                        );
            });
            services.AddTransient<IUserStore<ApplicationUser>, UserStore>(u => new UserStore(Configuration));
            services.AddTransient<IRoleStore<ApplicationRole>, RoleStore>(u => new RoleStore(Configuration));
            services.AddIdentity<ApplicationUser, ApplicationRole>()
           
                //.AddUserManager<ApplicationUserManager>()
                .AddDefaultTokenProviders();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new Int32Converter());
            });

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenHandler, Security.Tokens.TokenHandler>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddDomainServices(Configuration);
            services.Configure<Security.Tokens.TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<Security.Tokens.TokenOptions>();

            var signingConfigurations = new SigningConfigurations(tokenOptions.Secret);
            services.AddSingleton(signingConfigurations);
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddTransient<JwtMiddleware>();
            services.AddDistributedMemoryCache();// TODO: USe redis or SQL Server
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100);
                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true;
            });



            services.AddScoped<IEmailSender, EmailSender>();
            //services.AddTransient<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                  .AddJwtBearer(jwtBearerOptions =>
                  {
                      jwtBearerOptions.SaveToken = true;
                      jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                      {
                          RequireExpirationTime = true,
                          ValidateAudience = true,
                          ValidateLifetime = true,
                          ValidateIssuerSigningKey = true,
                          ValidIssuer = tokenOptions.Issuer,
                          ValidAudience = tokenOptions.Audience,
                          IssuerSigningKey = signingConfigurations.SecurityKey,
                          ClockSkew = TimeSpan.Zero
                      };
                  });

            SerilogConfig.Configure();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseSession();
            app.UseStaticHttpContext();
            WebHelpers.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            app.UseStaticFiles();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseJwtMiddleware();// or else             app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}