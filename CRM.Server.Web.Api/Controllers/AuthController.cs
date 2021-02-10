using AutoMapper;
using CRM.Server.Models;
using CRM.Server.Services;
using CRM.Server.Web.Api.Controllers.Resources;
using CRM.Server.Web.Api.Core.Security.Tokens;
using CRM.Server.Web.Api.Core.Services;
using CRM.Server.Web.Api.DataObjects.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IEmailSender _emailSender;
        public AuthController(IMapper mapper, IAuthenticationService authenticationService, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [Route("/api/auth/login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserCredentialsResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.CreateAccessTokenAsync(userCredentials.Email, userCredentials.Password);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var accessTokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(new
            {
                token = new
                {
                    access_token = accessTokenResource.AccessToken,
                    refresh_token = accessTokenResource.RefreshToken,
                    expires_in = accessTokenResource.Expiration,
                    roles = accessTokenResource.Roles
                }
            });
        }

        [Route("/api/auth/refresh-token")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenResource refreshTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.RefreshTokenAsync(refreshTokenResource.Token, refreshTokenResource.UserEmail);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var tokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(tokenResource);
        }

        [Route("/api/auth/tokenrevoke")]
        [HttpPost]
        public IActionResult RevokeToken(RevokeTokenResource revokeTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _authenticationService.RevokeRefreshToken(revokeTokenResource.Token);
            return NoContent();
        }

        [HttpPost]
        [Authorize]
        [Route("/api/auth/sign-out")]
        public async Task<IActionResult> SignOut()
        {

            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/auth/request-pass")]
        public async Task<IActionResult> RequestPassword(RequestPasswordDto requestPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(requestPasswordDto.Email);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            //var resetLink = Url.Action("Reset-Password",
            //                "Auth", new { token = token ,email = user.Email},
            //                 protocol: HttpContext.Request.Scheme);
            var resetLink = $"http://localhost:4300/auth/reset-password?email={user.Email}&token={token}";
            var pathString = "./MailTemplate/ForgotPassword.html";

            var builder = new StringBuilder();

            using (var reader = System.IO.File.OpenText(pathString))
            {
                builder.Append(reader.ReadToEnd());
            }

            builder.Replace("@resetlink", resetLink);
            builder.Replace("@UserName", user.UserName);
            await _emailSender.SendEmailAsync(requestPasswordDto.Email, "Reset Password", builder.ToString(), true);
            return Ok();
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("/api/auth/reset-pass")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequestDto requestDto)
        {
            var user = await _userManager.FindByNameAsync(requestDto.UserName);

            var result = await _userManager.ResetPasswordAsync(user, requestDto.Token, requestDto.Password);

            if (result.Succeeded)
            {

                return Ok(new { status = "success" });
            }
            else
            {
                return BadRequest("Error while resetting the password!");
            }
        }

    }


}