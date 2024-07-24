using WoodArtCons.Shared.DataTransferObjects;
using WoodArtCons.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.JSInterop;

namespace WoodArtCons.Services
{
    public class AuthProfileService : IAuthProfileService
    {
        //private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private readonly IConfiguration _configuration;

        public AuthProfileService(IJSRuntime jSRuntime, IConfiguration configuration)
        {
            //_httpClient = httpClient;
            _jsRuntime = jSRuntime;
            _configuration = configuration;
            //_httpClient.BaseAddress = new Uri("https://localhost:5001/");
        }

        public async Task<ClaimsDto> Me(string jwt)
        {
            var result = Mee();
            try
            {
                var ceva = await result;
                return ceva;
                //return await result.Content.ReadFromJsonAsync<ClaimsDto>();

            }
            catch (Exception e)
            {
                Console.WriteLine("Log", e);
            }
            return null;
        }

        public async Task<ClaimsDto> Mee()
        //public ClaimsDto Mee()
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
                //HttpContext.Request.Cookies.TryGetValue("token", out jwt);
                jwt = await _jsRuntime.InvokeAsync<string>("getToken");
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
}
