using Application.DTOs.Product.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface.Product;

public interface IProductService
{


    public Task<List<ProductReadOnlyDTO>> GetAllProducuts();
    public Task<ProductReadOnlyDTO> GetProductById(int ProductId);



    public Task<bool> CreateProduct(CreateProductDTO createproductDTO);

    public Task<bool> UpdateProduct(ProductDTO productDTO);

    public Task<bool> DeleteProduct(int ProductId);


    public Task<bool> ProductIsBuyed(int UserId, int CourseId);



    public Task<List<ProductReadOnlyDTO>> GetBuyedProductsByUserId(int UserId);





}
