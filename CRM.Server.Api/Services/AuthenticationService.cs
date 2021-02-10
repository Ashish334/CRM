using System.Linq;
using System.Threading.Tasks;
using CRM.Server.Models;
using CRM.Server.Web.Api.Core.Security.Tokens;
using CRM.Server.Web.Api.Core.Services;
using CRM.Server.Web.Api.Core.Services.Communication;
using Microsoft.AspNetCore.Identity;

namespace CRM.Server.Web.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ITokenHandler _tokenHandler;
        
        public AuthenticationService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<TokenResponse> CreateAccessTokenAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                return new TokenResponse(false, "Invalid credentials.", null);
            }
            var userRoles = await _userManager.GetRolesAsync(user); 
            var token = _tokenHandler.CreateAccessToken(user,userRoles.ToList());

            return new TokenResponse(true, null, token);
        }

        public async Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail)
        {
            var token = _tokenHandler.TakeRefreshToken(refreshToken);

            if (token == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            if (token.IsExpired())
            {
                return new TokenResponse(false, "Expired refresh token.", null);
            }

            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            
            var accessToken = _tokenHandler.CreateAccessToken(user,userRoles.ToList());
            return new TokenResponse(true, null, accessToken);
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            _tokenHandler.RevokeRefreshToken(refreshToken);
        }
    }
}