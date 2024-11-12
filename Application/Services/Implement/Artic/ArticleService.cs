using Application.DTOs.Article.AddDTO;
using Application.DTOs.Article.EditDTO;
using Application.DTOs.Article.ReadonlyDTO;
using AutoMapper;
using Domain.Entities.Article;
using Domain.IRepository.Article;
using Microsoft.AspNetCore.JsonPatch.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implement.Artic;

public class ArticleService
{


    #region Ctor

    private readonly IArticleRepository _ArticleRepository;
    private readonly IMapper _mapper;


    public ArticleService(IArticleRepository articleRepository, IMapper mapper)
    {
        _ArticleRepository = articleRepository;
        _mapper = mapper;
    }

    #endregion


    //Get All
    public async Task<List<ArticleReadonlyDTO>> GetAllArticle()
    {


        var articleDTOs = new List<ArticleReadonlyDTO>();

        var articles = await _ArticleRepository.GetAllArticles();

        if (articles == null)
            return articleDTOs;

        foreach (var article in articles)
        {
            var temp = _mapper.Map<ArticleReadonlyDTO>(article);

            articleDTOs.Add(temp);

        }


        return articleDTOs;


    }


    //Get By Id
    public async Task<ArticleReadonlyDTO> GetArticleById(int id)
    {


        var article = await _ArticleRepository.GetArticleById(id);

        if (article == null)
            return null;

        var temp = _mapper.Map<ArticleReadonlyDTO>(article);

        return temp;


    }


    //Add
    public async Task<bool> AddArticle(ArticleAddDTO dto)
    {
        if (dto == null)
            return false;


        var temp = _mapper.Map<Article>(dto);

        var result = await _ArticleRepository.AddArticle(temp);

        return result;




    }


    //Edit
    public async Task<bool> EditArticle(ArticleEditDTO dto)
    {
        if (dto == null)
            return false;


        var temp = _mapper.Map<Article>(dto);

        var result = await _ArticleRepository.EditArticle(temp);

        return result;

    }


    //Remove
    public async Task<bool> RemoveArticle(int Id)
    {

        var result = await _ArticleRepository.RemoveArticle(Id);


        return result;

    }


}
