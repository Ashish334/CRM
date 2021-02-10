using CRM.Server.Models;
using CRM.Server.Services;
using CRM.Server.Services.Domain;
using CRM.Server.Web.Api.DataObjects.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Server.Web.Api.Controllers
{
    [ApiController]
    public class UsersController : BaseAuthorizeController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserService _userService;
        private readonly RoleServices _userRole;
        private readonly IEmailSender _emailSender;
        private IWebHostEnvironment _env;


        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, UserService userService, RoleServices roleServices, IEmailSender emailSender, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _userRole = roleServices;
            _emailSender = emailSender;
            _env = env;

        }

        [HttpPost]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/users/loggeduser")]
        public async Task<IActionResult> GetLoggedUserAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = Request.HttpContext.Items["CurrentLoggedUser"] as ApplicationUser;
            if (user == null)
            {
                return NoContent();
            }

            string imagePath = Path.Combine(_env.WebRootPath, "user.png");
            byte[] imageByteArray = null;
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                imageByteArray = new byte[reader.BaseStream.Length];
                for (int i = 0; i < reader.BaseStream.Length; i++)
                    imageByteArray[i] = reader.ReadByte();
            }
            string base64String = "data:image/png;base64," + Convert.ToBase64String(imageByteArray, 0, imageByteArray.Length);
            var userResponse = new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                Picture = base64String,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,
                CreatedDateTimeUtc = user.CreatedDateTimeUtc,
                UpdatedDateTimeUtc = user.UpdatedDateTimeUtc,
                Roles = user.Roles,
                Status = user.Status
            };
            userResponse.Roles = (await _userManager.GetRolesAsync(user)).ToList();

            return Ok(userResponse);
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]//, Roles = "Admin"
        [Route("/api/users/create")]
        public async Task<IActionResult> CreateUserAsync(CreateUserRequestDto userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                FirstName = userCredentials.FirstName,
                LastName = userCredentials.LastName,
                UserName = userCredentials.Email,
                Email = userCredentials.Email,
                MobileNumber = userCredentials.MobileNumber ?? "",
                CreatedDateTimeUtc = DateTime.UtcNow,
                UpdatedDateTimeUtc = DateTime.UtcNow,
                Roles = userCredentials.Roles,
                Status=userCredentials.Status
            };

            var response = await _userManager.CreateAsync(user, userCredentials.Password);
            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }
            var pathString = "./MailTemplate/Register.html";

            var builder = new StringBuilder();

            using (var reader = System.IO.File.OpenText(pathString))
            {
                builder.Append(reader.ReadToEnd());
            }

            builder.Replace("@Name", $"{user.FirstName} {user.LastName}");
            builder.Replace("@Password", $"{userCredentials.Password}");

            builder.Replace("@UserName", user.UserName);
           // await _emailSender.SendEmailAsync(user.Email, "Register", builder.ToString(), true);


            if (userCredentials.Roles != null)
                foreach (var role in userCredentials.Roles)
                {
                    var isRoleExist = await _roleManager.RoleExistsAsync(role);
                    if (isRoleExist)
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }

            return Ok();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/users/{id}")]
        public async Task<IActionResult> GetUserAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NoContent();
            }

            var userResponse = new UserResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,
                CreatedDateTimeUtc = user.CreatedDateTimeUtc,
                UpdatedDateTimeUtc = user.UpdatedDateTimeUtc,
                Status=user.Status
            };
            userResponse.Roles = (await _userManager.GetRolesAsync(user)).ToList();

            return Ok(userResponse);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/users/getall")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var users = await _userService.GetAllUserAsync();
            if (users == null)
            {
                return NoContent();
            }
            var userResponseList = new List<UserResponseDto>();
            foreach (var user in users)
            {
                userResponseList.Add(new UserResponseDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MobileNumber = user.MobileNumber,
                    Roles = (await _userManager.GetRolesAsync(user)).ToList(),
                    CreatedDateTimeUtc = user.CreatedDateTimeUtc,
                    UpdatedDateTimeUtc = user.UpdatedDateTimeUtc,
                    Status=user.Status
                });

            }

            return Ok(userResponseList);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/users/getrole")]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            var roles = await _userRole.GetAllRoleAsync();
            if (roles == null)
            {
                return NoContent();
            }
            var userRoleList = new List<UserRoleDto>();
            foreach (var user in roles)
            {
                userRoleList.Add(new UserRoleDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    NormalizedName = user.NormalizedName

                });

            }

            return Ok(userRoleList);
        }

        [HttpPut]
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("/api/users/update")]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByIdAsync(requestDto.Id.ToString());

            if (user == null)
            {
                return NoContent();
            }

            user.Id = requestDto.Id;
            user.Email = requestDto.Email;
            user.FirstName = requestDto.FirstName;
            user.LastName = requestDto.LastName;
            user.MobileNumber = requestDto.MobileNumber ?? "";
            user.UpdatedDateTimeUtc = DateTime.UtcNow;
            user.Status = requestDto.Status;
            user.Roles = requestDto.Roles;

            var response = await _userManager.UpdateAsync(user);

            var existingRoles = await _userManager.GetRolesAsync(user);


            foreach (var item in existingRoles)
            {
                await _userManager.RemoveFromRoleAsync(user, item);
            }

            if (requestDto.Roles != null)
                foreach (var role in requestDto.Roles)
                {
                    var isRoleExist = await _roleManager.RoleExistsAsync(role);
                    if (isRoleExist)
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }
            if (response.Succeeded)
                return Ok();
            return BadRequest(response.Errors);
        }
    }
}