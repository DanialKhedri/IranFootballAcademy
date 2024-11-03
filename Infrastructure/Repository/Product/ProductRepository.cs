using Application.DTOs.Product.ProductDTO;
using Domain.IRepository.Product;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Product;

public class ProductRepository : IProductRepository
{

    #region Ctor


    private readonly DataContext _datacontext;


    public ProductRepository(DataContext datacontext)
    {

        _datacontext = datacontext;

    }

    #endregion


    public async Task<List<Domain.Entities.Product.Product>> GetAllProducuts()
    {

        return await _datacontext.Products.ToListAsync();


    }

    public async Task<Domain.Entities.Product.Product?> GetProductById(int ProductId)
    {
        return await _datacontext.Products.FirstOrDefaultAsync(p => p.Id == ProductId);

    }





    public async Task<bool> CreateProduct(Domain.Entities.Product.Product product)
    {


        try
        {
            await _datacontext.Products.AddAsync(product);
            await _datacontext.SaveChangesAsync();
            return true;

        }
        catch
        {

            return false;
        }

    }

    public async Task<bool> UpdateProduct(Domain.Entities.Product.Product product)
    {
        Domain.Entities.Product.Product tempproduct = await _datacontext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

        if (tempproduct != null)
        {

            tempproduct.Name = product.Name;
            tempproduct.Description = product.Description;
            tempproduct.Price = product.Price;

            if (product.ImageUrl != null)
                tempproduct.ImageUrl = product.ImageUrl;

            try
            {

                _datacontext.Products.Update(tempproduct);
                await _datacontext.SaveChangesAsync();
                return true;

            }
            catch
            {

                return false;
            }

        }
        else
            return false;
    }

    public async Task<bool> DeleteProduct(int ProductId)
    {



        try
        {
            var product = await _datacontext.Products.FirstOrDefaultAsync(p => p.Id == ProductId);

            if (product != null)
            {
                _datacontext.Products.Remove(product);
                await _datacontext.SaveChangesAsync();

                return true;

            }
            else
                return false;
        }
        catch
        {

            return false;
        }




    }

    //Product Is Buyed
    public async Task<bool> ProductIsBuyed(int UserId, int CourseId)
    {
        try
        {
            var IsBuyed = _datacontext.BuyedProducts.Any(c => c.UserId == UserId && c.ProductId == CourseId);
            return IsBuyed;
        }
        catch
        {

            return false;
        }
    }

    //Get Buyed Products By User Id
    public async Task<List<Domain.Entities.Product.Product>> GetBuyedProductsByUserId(int UserId)
    {

        try
        {
            var Products =  await _datacontext.BuyedProducts.Where(p => p.UserId == UserId)
                                                            .Select(p => p.Product)
                                                            .ToListAsync();

            return Products;
        }
        catch
        {

            return null;

        }



    }
}
