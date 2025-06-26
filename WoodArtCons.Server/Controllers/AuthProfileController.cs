using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AcademyCenter.Server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthProfileController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpGet("me")]
        public async Task<ClaimsDto> Me()
        {
            var jwt = "";

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(_configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha512 } // Specify the expected signing algorithm
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken = null;


            try
            {
                HttpContext.Request.Cookies.TryGetValue("token", out jwt);
                tokenHandler.ValidateToken(jwt, validationParameters, out validatedToken);
                var claims = new ClaimsDto((validatedToken as JwtSecurityToken).Claims);
                return claims;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception from controller", e);
                return null;
            }
        }
    }

    public class ClaimsDto
    {
        public string UserId { get; set; } = "userId";
        public string Role { get; set; } = "role";

        public ClaimsDto(string userId, string role)
        {
            UserId = userId;
            Role = role;
        }
        public ClaimsDto() { }

        public ClaimsDto(IEnumerable<Claim> claims)
        {
            UserId = claims.Single(c => c.Type == "userId").Value;
            Role = claims.Single(c => c.Type == "role").Value;
        }

        public static string Id = "userId";
        public static string UserRole = "role";
    }
}
