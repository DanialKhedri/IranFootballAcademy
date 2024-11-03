using Domain.Entities.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository.Product;

public interface IProductRepository
{

    public Task<List<Domain.Entities.Product.Product>> GetAllProducuts();
    public Task<Domain.Entities.Product.Product?> GetProductById(int ProductId);





    public Task<bool> CreateProduct(Domain.Entities.Product.Product product);

    public Task<bool> UpdateProduct(Domain.Entities.Product.Product product);

    public Task<bool> DeleteProduct(int ProductId);


    public Task<bool> ProductIsBuyed(int UserId, int CourseId);


    public Task<List<Domain.Entities.Product.Product>> GetBuyedProductsByUserId(int UserId);

}
