
//using Blazored.LocalStorage;
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;

//namespace DanCode_Blazor.Providers;

//public class ApiAuthenticationStateProvider : AuthenticationStateProvider
//{
//    private readonly ILocalStorageService _localStorage;
//    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

//    public ApiAuthenticationStateProvider(ILocalStorageService localStorageService)
//    {
//        _localStorage = localStorageService;
//        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
//    }

//    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//    {
//        string? tokenJwt = await _localStorage.GetItemAsync<string>("accessToken");

//        if (string.IsNullOrEmpty(tokenJwt))
//        {
//            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
//        }

//        try
//        {
//            var jwtToken = _jwtSecurityTokenHandler.ReadJwtToken(tokenJwt);
//            var claims = jwtToken.Claims.ToList();
//            var identity = new ClaimsIdentity(claims, "jwt");
//            var user = new ClaimsPrincipal(identity);

//            // Validate token expiration
//            if (jwtToken.ValidTo < DateTime.UtcNow)
//            {
//                // Token is expired, handle appropriately
//                await Loggedout();
//                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
//            }

//            return new AuthenticationState(user);
//        }
//        catch (Exception)
//        {
//            // Handle exceptions, maybe log the error
//            await Loggedout();
//            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
//        }
//    }

//    public async Task LoggedIn(string token)
//    {
//        await _localStorage.SetItemAsync("accessToken", token);
//        var claims = _jwtSecurityTokenHandler.ReadJwtToken(token).Claims;
//        var identity = new ClaimsIdentity(claims, "jwt");
//        var user = new ClaimsPrincipal(identity);
//        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
//    }

//    public async Task Loggedout()
//    {
//        await _localStorage.RemoveItemAsync("accessToken");
//        var noBody = new ClaimsPrincipal(new ClaimsIdentity());
//        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(noBody)));
//    }
//}



using Blazored.LocalStorage;
using DanCode_Blazor.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using Services.Base.interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace DanCode_Blazor.Providers;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly IUserService _UserService; // اضافه کردن سرویس احراز هویت
    private readonly HttpClient _httpClient; // اضافه کردن HttpClient برای ارسال درخواست‌ها

    public ApiAuthenticationStateProvider(ILocalStorageService localStorageService, HttpClient httpClient, IClient client, IUserService userService)
    {
        _localStorage = localStorageService;
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        _httpClient = httpClient;
        _UserService = userService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string? tokenJwt = await _localStorage.GetItemAsync<string>("accessToken");

        if (string.IsNullOrEmpty(tokenJwt))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        try
        {
            var jwtToken = _jwtSecurityTokenHandler.ReadJwtToken(tokenJwt);
            var claims = jwtToken.Claims.ToList();
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            // Validate token expiration
            if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                // Token is expired, attempt to refresh it
                bool isRefreshed = await TryRefreshToken();

                if (!isRefreshed)
                {
                    await Loggedout();
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                // After successful refresh, get the updated token
                tokenJwt = await _localStorage.GetItemAsync<string>("accessToken");
                jwtToken = _jwtSecurityTokenHandler.ReadJwtToken(tokenJwt);
                claims = jwtToken.Claims.ToList();
                identity = new ClaimsIdentity(claims, "jwt");
                user = new ClaimsPrincipal(identity);
            }

            // Set Authorization header for HttpClient
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

            return new AuthenticationState(user);
        }
        catch (Exception)
        {
            await Loggedout();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }

    private async Task<bool> TryRefreshToken()
    {
        var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");
        if (string.IsNullOrEmpty(refreshToken))
        {
            return false;
        }

   
        var  response = await _UserService.RefreshToken(refreshToken);

        var newaccesstoken = response.Data.Token;

        if (newaccesstoken == null || string.IsNullOrEmpty(newaccesstoken))
        {
            return false;
        }

        // Save new tokens
        await _localStorage.SetItemAsync("accessToken", newaccesstoken);
     

        return true;
    }

    public async Task LoggedIn(string accessToken, string refreshToken)
    {
        await _localStorage.SetItemAsync("accessToken", accessToken);
        await _localStorage.SetItemAsync("refreshToken", refreshToken);
        var claims = _jwtSecurityTokenHandler.ReadJwtToken(accessToken).Claims;
        var identity = new ClaimsIdentity(claims, "jwt");
        var user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public async Task Loggedout()
    {
        await _localStorage.RemoveItemAsync("accessToken");
        await _localStorage.RemoveItemAsync("refreshToken");
        var noBody = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(noBody)));
    }
}
