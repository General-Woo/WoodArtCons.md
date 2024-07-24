using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Security.Claims;
using WoodArtCons.Interfaces;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IJSRuntime _jsRuntime;
    private readonly IAuthProfileService _authProfileService;
    //private bool _isInitialized = false;
    private AuthenticationState _anonymousState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

    public CustomAuthStateProvider(HttpClient httpClient, IConfiguration configuration, IJSRuntime jSRuntime, IAuthProfileService authProfileService)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _jsRuntime = jSRuntime;
        _authProfileService = authProfileService;
    }

    //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    //{
    //    if (_isInitialized)
    //    {
    //        return _anonymousState;
    //    }

    //    return await Task.FromResult(_anonymousState);
    //}

    //public async Task InitializeAuthenticationStateAsync()
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string authToken = await _jsRuntime.InvokeAsync<string>("getToken");
        var identity = new ClaimsIdentity();
        var claims = new List<Claim>();

        _httpClient.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrEmpty(authToken))
        {
            try
            {
                var claimDto = await _authProfileService.Me(authToken);

                claims.Add(new Claim("userId", claimDto.UserId));
                claims.Add(new Claim("role", claimDto.Role));

                identity = new ClaimsIdentity(claims, "jwt");

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken.Replace("\"", ""));
            }
            catch (Exception)
            {
                identity = new ClaimsIdentity();
            }
        }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        //_isInitialized = true;
        _anonymousState = state;

        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }

    public async Task Logout()
    {
        await _jsRuntime.InvokeVoidAsync("removeJwtFromCookie", "token");
        _anonymousState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        NotifyAuthenticationStateChanged(Task.FromResult(_anonymousState));
    }
}