using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product.Category;

public class Category
{

    //Properties

    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }


    //Navigation Properties

    public ICollection<SelectedCategory.SelectedCategory> SelectedCategories { get; set; }

}
