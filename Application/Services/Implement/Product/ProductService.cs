#region Usings
using Application.DTOs.Product.ProductDTO;
using Application.Services.Interface.Product;
using AutoMapper;
using Domain.IRepository.Course;
using Domain.IRepository.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Application.Services.Implement.Product;

public class ProductService : IProductService
{

    #region Ctor

    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    #endregion


    public async Task<List<ProductReadOnlyDTO>> GetAllProducuts()
    {
        var originproducts = await _productRepository.GetAllProducuts();

        List<ProductReadOnlyDTO> productDTOs = new List<ProductReadOnlyDTO>();

        if (originproducts != null)
        {
            foreach (var originproduct in originproducts)
            {

                var productdto = _mapper.Map<ProductReadOnlyDTO>(originproduct);
                productDTOs.Add(productdto);

            }

            return productDTOs;


        }

        else
            return productDTOs;
    }
    public async Task<ProductReadOnlyDTO> GetProductById(int ProductId)
    {
        var originproduct = await _productRepository.GetProductById(ProductId);

        if (originproduct != null)
        {
            var readonlydto = _mapper.Map<ProductReadOnlyDTO>(originproduct);

            return readonlydto;

        }
        else
            return null;
    }
    public async Task<bool> CreateProduct(CreateProductDTO createproductDTO)
    {
        if (createproductDTO != null)
        {
            var product = _mapper.Map<Domain.Entities.Product.Product>(createproductDTO);

            return await _productRepository.CreateProduct(product);
        }
        else
            return false;

    }
    public async Task<bool> UpdateProduct(ProductDTO productDTO)
    {
        if (productDTO != null)
        {
            var product = _mapper.Map<Domain.Entities.Product.Product>(productDTO);

            return await _productRepository.UpdateProduct(product);
        }
        else
            return false;
    }
    public async Task<bool> DeleteProduct(int ProductId)
    {
        if (ProductId != null)
        {
            return await _productRepository.DeleteProduct(ProductId);

        }
        else
            return false;
    }



    //Product Is Buyed?
    public async Task<bool> ProductIsBuyed(int UserId, int ProductId)
    {

        return await _productRepository.ProductIsBuyed(UserId, ProductId);

    }


    //Get Buyed Products By User Id
    public async Task<List<ProductReadOnlyDTO>> GetBuyedProductsByUserId(int UserId)
    {



        var Products = await _productRepository.GetBuyedProductsByUserId(UserId);

        List<ProductReadOnlyDTO> ProductDTOs = new List<ProductReadOnlyDTO>();

        if (Products != null)
        {
            foreach (var item in Products)
            {

                var temp = _mapper.Map<ProductReadOnlyDTO>(item);

                ProductDTOs.Add(temp);

            }

            return ProductDTOs;
        }

        else
        {
            return null;
        }


    }

    
}
