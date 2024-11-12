using Application.DTOs.Article.ReadonlyDTO;
using Domain.Entities.Article;
using Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Article;

namespace Infrastructure.Repository.Article;

public class ArticleRepository
{

    #region Ctor

    private readonly DataContext _datacontext;

    public ArticleRepository(DataContext datacontext)
    {
        _datacontext = datacontext;
    }




    #endregion


    //Get All
    public async Task<List<Domain.Entities.Article.Article>> GetAllArticles()
    {

        try
        {


            var articles = await _datacontext.Articles.ToListAsync();

            return articles;


        }
        catch
        {

            return null;
        }


    }

    //Get By ID
    public async Task<Domain.Entities.Article.Article?> GetArticleById(int Id)
    {
        try
        {
            var artcle = await _datacontext.Articles.FirstOrDefaultAsync(x => x.Id == Id);

            return artcle;

        }
        catch
        {

            return null;
        }

    }

    //Add
    public async Task<bool> AddArticle(Domain.Entities.Article.Article article)
    {

        try
        {

            await _datacontext.Articles.AddAsync(article);
            await _datacontext.SaveChangesAsync();

            return true;
        }
        catch
        {

            return false;
        }


    }

    //Edit
    public async Task<bool> EditArticle(Domain.Entities.Article.Article article)
    {
        try
        {

            var Originarticle = await _datacontext.Articles.FirstOrDefaultAsync(x => x.Id == article.Id);

            if (Originarticle == null)
                return false;


            Originarticle.Author = article.Author;
            Originarticle.Content = article.Content;
            Originarticle.Title = article.Title;
            Originarticle.ImageURL = article.ImageURL;

            await _datacontext.SaveChangesAsync();

            return true;

        }
        catch
        {

            return false;
        }

    }


    //Remove
    public async Task<bool> RemoveArticle(int Id)
    {
        try
        {

            var originarticle = await _datacontext.Articles.FirstOrDefaultAsync(x => x.Id == Id);

            if (originarticle == null)
                return false;


            _datacontext.Remove(originarticle);

            await _datacontext.SaveChangesAsync();

            return true;

        }
        catch
        {

            return false;
        }

    }

}
