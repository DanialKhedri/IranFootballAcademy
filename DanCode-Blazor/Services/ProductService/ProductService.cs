using Blazored.LocalStorage;
using DanCode_Blazor.Components.Pages.AdminSide.Users;
using DanCode_Blazor.Services.Base;
using DanCode_Blazor.Services.Base.interfaces;
using Services.Base.interfaces;

namespace DanCode_Blazor.Services.ProductService;

public class ProductService : BaseHttpService, IProductService
{

    #region Ctor

    private readonly IClient client;
    public ProductService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        this.client = client;
    }

    #endregion


    //Add Product
    public async Task<Response<bool>> AddProduct(CreateProductDTO dto)
    {
        Response<bool> response;
        try
        {
            await GetBearerToken();
            var data = await client.CreateProductAsync(dto);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };
        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }
        return response;

    }


    //Edit Product
    public async Task<Response<bool>> EditProduct(ProductDTO dto)
    {
        Response<bool> response;
        try
        {
            await GetBearerToken();
            var data = await client.UpdateProductAsync(dto);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }
        return response;
    }

    //Remove Product 
    public async Task<Response<bool>> RemoveProduct(int ProductId)
    {
        Response<bool> response;
        try
        {
            await GetBearerToken();
            var data = await client.DeleteProductAsync(ProductId);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }
        return response;


    }

    //Product IsBuyed
    public async Task<Response<bool>> ProductIsBuyed(int UserId, int ProductId)
    {
        Response<bool> response;
        try
        {
            await GetBearerToken();
            var data = await client.ProductIsBuyedAsync(UserId, ProductId);

            response = new Response<bool>
            {
                Data = data,
                Success = true,
            };

        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<bool>(exception);

        }
        return response;
    }


    //Get Buyed Produtcs By UserId
    public async Task<Response<List<ProductReadOnlyDTO>>> GetBuyedProductsByUserId(int UserId)
    {


        Response<List<ProductReadOnlyDTO>> response;

        try
        {

            await GetBearerToken(); 
            var data = await client.GetBuyedProductsByUserIdAsync(UserId);


            response = new Response<List<ProductReadOnlyDTO>>
            {
                Data = data.ToList(),
                Success = true,
            };
        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<List<ProductReadOnlyDTO>>(exception);

        }

        return response;

    }

}
