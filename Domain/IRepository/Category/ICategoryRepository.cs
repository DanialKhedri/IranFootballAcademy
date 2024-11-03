using Domain.Entities.Product.SelectedCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.Category;

public interface ICategoryRepository
{

    //Get All Categories
    public  Task<List<Domain.Entities.Product.Category.Category>> GetAllCategories();
   

    //Get Category By Id
    public Task<Domain.Entities.Product.Category.Category> GetCategoryById(int CategoryId);


    //Create
    public  Task<bool> CreateCategory(Domain.Entities.Product.Category.Category category);
   
    //Edit
    public  Task<bool> UpdateCategory(Domain.Entities.Product.Category.Category category);
   

    //Delete
    public  Task<bool> DeleteCategory(int CategoryId);
    

    //Add Product To Category
    public  Task<bool> AddProductToCategory(int ProductId, List<int> CategoryIds);
    

    







}
