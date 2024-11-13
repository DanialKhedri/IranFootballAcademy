using Blazored.LocalStorage;
using DanCode_Blazor.Components.Pages.AdminSide.Article;
using DanCode_Blazor.Services.Base;
using DanCode_Blazor.Services.Base.interfaces;

namespace DanCode_Blazor.Services.ArticleService;

public class ArticlesService : BaseHttpService, IArticleService
{
    #region Ctor

    private readonly IClient client;
    public ArticlesService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        this.client = client;
    }

    #endregion

    //Get All
    public async Task<Response<List<ArticleReadonlyDTO>>> GetAllArticles()
    {


        Response<List<ArticleReadonlyDTO>> response;

        try
        {
            var data = await client.GetAllArticlesAsync();


            response = new Response<List<ArticleReadonlyDTO>>
            {
                Data = data.ToList(),
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<List<ArticleReadonlyDTO>>(exception);

        }

        return response;

    }

    //Get By ID
    public async Task<Response<ArticleReadonlyDTO>> GetArticleById(int Id) 
    {
        Response<ArticleReadonlyDTO> response;

        try
        {
            var data = await client.GetArticleByIdAsync(Id);


            response = new Response<ArticleReadonlyDTO>
            {
                Data = data,
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<ArticleReadonlyDTO>(exception);

        }

        return response;
    }

    //Add
    public async Task<Response<bool>> AddArticle(ArticleAddDTO dto) 
    {

        Response<bool> response;

        try
        {

            await GetBearerToken();
            var data = await client.AddArticleAsync(dto);


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


    //Edit
    public async Task<Response<bool>> EditArticle(ArticleEditDTO dto)
    {

        Response<bool> response;

        try
        {

            await GetBearerToken();
            var data = await client.EditArticleAsync(dto);


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



    //Remove
    public async Task<Response<bool>> RemoveArticle(int Id)
    {
        Response<bool> response;

        try
        {

            await GetBearerToken();
            var data = await client.RemoveArticleAsync(Id);


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