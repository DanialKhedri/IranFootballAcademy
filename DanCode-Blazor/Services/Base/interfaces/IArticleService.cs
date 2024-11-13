namespace DanCode_Blazor.Services.Base.interfaces;

public interface IArticleService
{
    //Get All
    public Task<Response<List<ArticleReadonlyDTO>>> GetAllArticles();


    //Get By ID
    public Task<Response<ArticleReadonlyDTO>> GetArticleById(int Id);



    //Add
    public Task<Response<bool>> AddArticle(ArticleAddDTO dto);



    //Edit
    public Task<Response<bool>> EditArticle(ArticleEditDTO dto);



    //Remove
    public Task<Response<bool>> RemoveArticle(int Id);







}
