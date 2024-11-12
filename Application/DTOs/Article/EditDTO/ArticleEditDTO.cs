using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Article.EditDTO;

public class ArticleEditDTO
{

    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public string Author { get; set; }

    public DateTime PublishDate { get; set; }

    public string ImageURL { get; set; }

}
