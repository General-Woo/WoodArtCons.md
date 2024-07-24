using WoodArtCons.Shared.DataTransferObjects;

namespace WoodArtCons.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResult> Login(UserLoginDto request);
        Task<string> Logout();
    }

    public class LoginResult
    {
        public string Token { get; set; } = string.Empty;
        public string ResponseMessage { get; set; } = string.Empty;
        public bool IsSuccessfull { get; set; } = true;
    }
}
