using Application.DTOs.Article.ReadonlyDTO;
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

    public ArticleService(IArticleRepository articleRepository)
    {
        _ArticleRepository = articleRepository;
    }

    #endregion

    public async Task<List<ArticleReadonlyDTO>> GetAllArticle()
    {


        var articleDTOs = new List<ArticleReadonlyDTO>();

        var articles = await


    }











}
