using Blazored.LocalStorage;
using DanCode_Blazor.Providers;
using DanCode_Blazor.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace DanCode_Blazor.Services.Authentication;



public class AuthenticationService : IAuthenticationService
{
    #region Ctor

    private readonly IClient _httpClient;
    private readonly ILocalStorageService _localStorageService;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(IClient httpClient, ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider)
    {
        this._httpClient = httpClient;
        this._localStorageService = localStorageService;
        _authenticationStateProvider = authenticationStateProvider;
    }
    #endregion

    public async Task<bool> AuthenticateAsync(UserLogInDTO userLogInDTO)
    {


        var response = await _httpClient.LogInAsync(userLogInDTO);

        if (response.JwtToken == null)
            return false;


        //Store Token
        await _localStorageService.SetItemAsync("accessToken", response.JwtToken);


        //Change Auth State of App
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn(response.JwtToken,response.RefreshToken);



        return true;


    }


    public async Task<bool> AuthenticateWithSmsAsync(VerifyOtpModel verifyOtp)
    {


        var response = await _httpClient.VerifyOtpAsync(verifyOtp);

        if (response.JwtToken == null)
            return false;


        //Store Token
        await _localStorageService.SetItemAsync("accessToken", response.JwtToken);


        //Change Auth State of App
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn(response.JwtToken, response.RefreshToken);



        return true;


    }

    public async Task LogOut()
    {
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).Loggedout();
    }
}



public interface IAuthenticationService
{
    public Task<bool> AuthenticateAsync(UserLogInDTO userLogInDTO);

    public Task<bool> AuthenticateWithSmsAsync(VerifyOtpModel verifyOtp);

    public Task LogOut();



}


