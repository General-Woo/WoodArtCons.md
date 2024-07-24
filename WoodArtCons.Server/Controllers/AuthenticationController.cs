using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WoodArtCons.Server.WoodArtCons.Application.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace WoodArtCons.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> Login(UserLoginDto request)
        {
            var command = new LoginCommand(request);
            var result = await _mediator.Send(command);

            HttpContext.Response.Cookies.Append("token", result.Token, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None,
            });

            return result;
        }

        [HttpGet("log-out")]
        public async Task<ActionResult<string>> LogOut()
        {
            //AuthHelper.RemoveUserKey();
            Response.Cookies.Delete("token");

            return Ok("");
        }
    }
}
