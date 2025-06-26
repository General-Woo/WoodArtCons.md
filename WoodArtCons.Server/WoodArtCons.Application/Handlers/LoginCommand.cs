using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using WoodArtCons.Server.WoodArtCons.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WoodArtCons.Server.WoodArtCons.Application.Handlers
{
    public class LoginCommand : IRequest<LoginResult>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public LoginCommand(UserLoginDto model)
        {
            Email = model.Email;
            Password = model.Password;
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;

        public LoginCommandHandler(IConfiguration configuration, AppDbContext appDbContext)
        {
            _configuration = configuration;
            _appDbContext = appDbContext;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginResult response = new LoginResult();

            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == request.Email.ToLower());

            if (user == null)
            {
                response.ResponseMessage = "Wrong credentials!";
                response.IsSuccessfull = false;
            }
            else if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.ResponseMessage = "Wrong credentials!";
                response.IsSuccessfull = false;
            }
            else
            {
                response.Token = CreateToken(user);
                response.ResponseMessage = "Success!";
            }

            return response;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var result = computedHash.SequenceEqual(passwordHash);
                return result;
            }
        }

        private string CreateToken(Persistence.Entities.User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("role", user.Role.ToString()),
            };

            var key = new SymmetricSecurityKey(Convert.FromBase64String(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken
                (
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }



    public class LoginResult
    {
        public string Token { get; set; } = string.Empty;
        public string ResponseMessage { get; set; } = string.Empty;
        public bool IsSuccessfull { get; set; } = true;
    }

    public class UserLoginDto
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
