using Blazored.LocalStorage;
using DanCode_Blazor.Services.Base;
using Services.Base.interfaces;

namespace Services.UserService;

public class UserService : BaseHttpService, IUserService
{
    private readonly IClient client;

    public UserService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        this.client = client;
    }


    //Get ALl Users
    public async Task<Response<List<UserReadonlyDTO>>> GetAllUsers()
    {
        Response<List<UserReadonlyDTO>> response;


        try
        {

            await GetBearerToken();
            var data = await client.GetAllUsersAsync();

            response = new Response<List<UserReadonlyDTO>>
            {
                Data = data.ToList(),
                Success = true,
            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<List<UserReadonlyDTO>>(exception);

        }

        return response;
    }


    //Refresh Token
    public async Task<Response<AccessToken>> RefreshToken(string AccessToken) 
    {
        Response<AccessToken> response;


        try
        {

    
            var data = await client.RefreshTokenAsync(AccessToken);

            response = new Response<AccessToken>
            {
                Data = data,
                Success = true,
            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<AccessToken>(exception);

        }

        return response;
    }

    //IsAdmin
    public async Task<Response<bool>> IsAdmin(int UserId)
    {
        Response<bool> response;


        try
        {

            await GetBearerToken();
            var data = await client.UserIsAdminAsync(UserId);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }

        return response;
    }


    //UpdateUserAdminStatus
    public async Task<Response<bool>> UpdateUserAdminStatus(int userId, bool isAdmin) 
    {
        Response<bool> response;


        try
        {

            await GetBearerToken();
            var data = await client.UpdateUserAdminStatusAsync(userId, isAdmin);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }

        return response;
    }


    //Course Is Buyed
    public async Task<Response<bool>> CourseIsBuyed(int UserId, int CourseId)
    {
        Response<bool> response;


        try
        {

            await GetBearerToken();
            var data = await client.CourseIsBuyedAsync(UserId, CourseId);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }

        return response;

    }
}

