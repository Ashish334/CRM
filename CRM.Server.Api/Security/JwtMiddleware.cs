using CRM.Server.Models;
using CRM.Server.Web.Api.Security.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.Security
{
    public static class JwtMiddlewareExtension
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<JwtMiddleware>();
        }
    }

    public class JwtMiddleware: IMiddleware
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Tokens.TokenOptions _tokenOptions;
        private readonly SigningConfigurations _signingConfigurations;

        public JwtMiddleware(UserManager<ApplicationUser> userManager ,IOptions<Tokens.TokenOptions> tokenOptionsSnapshot, SigningConfigurations signingConfigurations)
        {
            _userManager = userManager;
            _signingConfigurations = signingConfigurations;
            _tokenOptions = tokenOptionsSnapshot.Value;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
               await attachUserToContext(context, token);

           await next(context);
        }

        private async Task attachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _signingConfigurations.SecurityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "sub").Value;

                // attach user to context on successful jwt validation
                context.Items["CurrentLoggedUser"] = await _userManager.FindByIdAsync(userId);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}