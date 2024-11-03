#region usings
using Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Application.Services.Interface.Category;

public interface ICategoryService
{

    //Get All Categories
    public Task<List<CategoryDTO>> GetAllCategories();


    //Get Category By Id
    public Task<CategoryDTO> GetCategoryById(int CategoryId);


    //Create
    public Task<bool> CreateCategory(CategoryCreateDTO categoryCreateDTO);

    //Edit
    public Task<bool> UpdateCategory(CategoryDTO categoryDTO);


    //Delete
    public Task<bool> DeleteCategory(int CategoryId);


    //Add Product To Category
    public Task<bool> AddProductToCategory(int ProductId, List<int> CategoryIds);









}
