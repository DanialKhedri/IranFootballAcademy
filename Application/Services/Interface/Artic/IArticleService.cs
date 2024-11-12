using Application.DTOs.Article.AddDTO;
using Application.DTOs.Article.EditDTO;
using Application.DTOs.Article.ReadonlyDTO;
using Domain.Entities.Article;
using Domain.IRepository.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface.Artic;

public interface IArticleService
{


    //Get All
    public Task<List<ArticleReadonlyDTO>> GetAllArticle();




    //Get By Id
    public  Task<ArticleReadonlyDTO> GetArticleById(int id);



    //Add
    public Task<bool> AddArticle(ArticleAddDTO dto);



    //Edit
    public Task<bool> EditArticle(ArticleEditDTO dto);



    //Remove
    public Task<bool> RemoveArticle(int Id);
 


}
