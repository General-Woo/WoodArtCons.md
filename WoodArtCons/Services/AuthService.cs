using Microsoft.JSInterop;
using WoodArtCons.Interfaces;
using WoodArtCons.Shared.DataTransferObjects;

namespace WoodArtCons.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsruntime;
        public AuthService(HttpClient httpClient, IJSRuntime jSRuntime)
        {
            _httpClient = httpClient;
            _jsruntime = jSRuntime;
        }

        public async Task<LoginResult> Login(UserLoginDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/authentication/login", request);
            var res = await result.Content.ReadFromJsonAsync<LoginResult>();
            await _jsruntime.InvokeVoidAsync("setToken", res.Token);
            return res;
        }

        public async Task<string> Logout()
        {
            var result = await _httpClient.GetAsync("api/authentication/log-out");
            var res = await result.Content.ReadAsStringAsync();
            await _jsruntime.InvokeVoidAsync("removeTokenFromCookie");
            return res;
        }
    }
}
