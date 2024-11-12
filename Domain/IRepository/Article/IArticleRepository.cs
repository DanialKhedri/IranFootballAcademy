using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.Article;

public interface IArticleRepository
{
    public Task<List<Domain.Entities.Article.Article>> GetAllArticles();





}
