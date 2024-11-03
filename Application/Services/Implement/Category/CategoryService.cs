#region usings
using Application.DTOs.Category;
using Application.Services.Interface.Category;
using AutoMapper;
using Domain.IRepository.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
#endregion

namespace Application.Services.Implement.Category;

public class CategoryService : ICategoryService
{

    #region Ctor

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }


    #endregion

    public async Task<List<CategoryDTO>> GetAllCategories()
    {
        var Categories = await _categoryRepository.GetAllCategories();

        List<CategoryDTO> CategoriesDTO = new List<CategoryDTO>();

        if (Categories != null)
        {

            foreach (var item in Categories)
            {
                var temp = _mapper.Map<CategoryDTO>(item);
                CategoriesDTO.Add(temp);

            }

            return CategoriesDTO;

        }
        else
            return null;
    }

    public async Task<bool> AddProductToCategory(int ProductId, List<int> CategoryIds)
    {
        return await _categoryRepository.AddProductToCategory(ProductId, CategoryIds);
    }

    public async Task<bool> CreateCategory(CategoryCreateDTO categoryCreateDTO)
    {


        if (categoryCreateDTO != null)
        {


            var Category = _mapper.Map<Domain.Entities.Product.Category.Category>(categoryCreateDTO);
            return await _categoryRepository.CreateCategory(Category);
        }
        else
            return false;


    }

    public async Task<bool> DeleteCategory(int CategoryId)
    {
        return await _categoryRepository.DeleteCategory(CategoryId);
    }



    public async Task<CategoryDTO> GetCategoryById(int CategoryId)
    {
        var category = await _categoryRepository.GetCategoryById(CategoryId);

        if (category != null)
        {
            var CategoryDTO = _mapper.Map<CategoryDTO>(category);

            return CategoryDTO;
        }
        else
            return null;

    }

    public async Task<bool> UpdateCategory(CategoryDTO categoryDTO)
    {

        if (categoryDTO != null)
        {
            var Category = _mapper.Map<Domain.Entities.Product.Category.Category>(categoryDTO);
            return await _categoryRepository.UpdateCategory(Category);

        }
        else
            return false;



    }
}
