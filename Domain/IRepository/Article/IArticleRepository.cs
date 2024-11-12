using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.Article;

public interface IArticleRepository
{
    //Get All
    public Task<List<Domain.Entities.Article.Article>> GetAllArticles();



    //Get By ID
    public Task<Domain.Entities.Article.Article?> GetArticleById(int Id);


    //Add
    public Task<bool> AddArticle(Domain.Entities.Article.Article article);



    //Edit
    public Task<bool> EditArticle(Domain.Entities.Article.Article article);



    //Remove
    public Task<bool> RemoveArticle(int Id);
    


}
