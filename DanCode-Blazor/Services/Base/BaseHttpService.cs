using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace DanCode_Blazor.Services.Base;

public class BaseHttpService
{

    private readonly IClient client;
    private readonly ILocalStorageService localStorage;

    public BaseHttpService(IClient client, ILocalStorageService localStorage)
    {
        this.client = client;
        this.localStorage = localStorage;
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
    {
        if (apiException.StatusCode == 400)
        {
            return new Response<Guid>() { Message = "validation Error Have Occured.", ValidationErrors = apiException.Response, Success = false };
        }

        if (apiException.StatusCode == 404)
        {
            return new Response<Guid>() { Message = "The Requested item Could Not be Found.", ValidationErrors = apiException.Response, Success = false };
        }

        if (apiException.StatusCode == 400)
        {
            return new Response<Guid>() { Message = "validation Error Have Occured.", Success = false };
        }

        return new Response<Guid>() { Message = "Something Went Wrong,Please Try Again", Success = false };

    }

    protected async Task GetBearerToken()
    {

        var Token = await localStorage.GetItemAsync<string>("accessToken");
        if (Token != null)
        {
            client.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Token);
        }

    }

}





