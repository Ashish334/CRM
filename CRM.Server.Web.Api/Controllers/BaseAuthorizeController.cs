using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace CRM.Server.Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseAuthorizeController : ControllerBase
    {
        protected String UserName => HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
    }
}
