using Blazored.LocalStorage;
using DanCode_Blazor.Services.Base;
using DanCode_Blazor.Services.Base.interfaces;
using System.Collections.Generic;

namespace DanCode_Blazor.Services.OrderService;

public class OrderService : BaseHttpService, IOrderService
{

    #region Ctor

    private readonly IClient client;
    public OrderService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        this.client = client;
    }

    #endregion

    //Get Cart
    public async Task<Response<Cart>> GetCart(int UserId)
    {

        Response<Cart> response;

        try
        {

            await GetBearerToken();

            var data = await client.GetCartAsync(UserId);


            response = new Response<Cart>
            {
                Data = data,
                Success = true,
            };


        }

        catch (ApiException exception)
        {

            response = ConvertApiExceptions<Cart>(exception);

        }

        return response;


    }

    //Get OrderDetails By OrderId

    public async Task<Response<ICollection<OrderDetailDTO>>> GetOrderDetailsByOrderId(int OrderId)
    {
        Response<ICollection<OrderDetailDTO>> response;

        try
        {

            await GetBearerToken();

            var data = await client.GetOrderDetailsByOrderIdAsync(OrderId);


            response = new Response<ICollection<OrderDetailDTO>>
            {
                Data = data,
                Success = true,
            };


        }

        catch (ApiException exception)
        {

            response = ConvertApiExceptions<ICollection<OrderDetailDTO>>(exception);

        }

        return response;
    }


    //Get All Finalized Orders
    public async Task<Response<ICollection<OrderDTO>>> GetAllFinalizedOrders()
    {


        Response<ICollection<OrderDTO>> response;

        try
        {

            await GetBearerToken();

            var data = await client.GetAllFinalizedOrderAsync();


            response = new Response<ICollection<OrderDTO>>
            {
                Data = data,
                Success = true,
            };


        }

        catch (ApiException exception)
        {

            response = ConvertApiExceptions<ICollection<OrderDTO>>(exception);

        }

        return response;










    }

    //Add Course To Cart
    public async Task<Response<bool>> AddCourseToCart(int UserId, int CourseId)
    {

        Response<bool> response;

        try
        {

            await GetBearerToken();

            var data = await client.AddCourseToCartAsync(UserId, CourseId);


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


    //Add Product To Cart
    public async Task<Response<bool>> AddProductToCart(int UserId, int ProductId)
    {

        Response<bool> response;
        try
        {
            await GetBearerToken();
            var data = await client.AddProductToCartAsync(UserId, ProductId);


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


    //Remove OrderDetail
    public async Task<Response<bool>> RemoveOrderDetail(int OrderDetailId)
    {

        Response<bool> response;

        try
        {

            await GetBearerToken();

            var data = await client.DeleteOrderDetailFromOrderAsync(OrderDetailId);


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

    //Get Finalize Orders By User Id 
    public async Task<Response<ICollection<OrderDTO>>> GetFinalizedOrderByUserId(int UserId)
    {

        Response<ICollection<OrderDTO>> response;

        try
        {

            await GetBearerToken();

            var data = await client.GetFinalizedOrdersByUserIdAsync(UserId);


            response = new Response<ICollection<OrderDTO>>
            {
                Data = data,
                Success = true,
            };


        }

        catch (ApiException exception)
        {

            response = ConvertApiExceptions<ICollection<OrderDTO>>(exception);

        }

        return response;



    }



    //Get Last 5 Orders
    public async Task<Response<ICollection<OrderDTO>>> GetLastFiveOrders()
    {

        Response<ICollection<OrderDTO>> response;

        try
        {

            await GetBearerToken();

            var data = await client.GetLastFiveOrderAsync();


            response = new Response<ICollection<OrderDTO>>
            {
                Data = data,
                Success = true,
            };


        }

        catch (ApiException exception)
        {

            response = ConvertApiExceptions<ICollection<OrderDTO>>(exception);

        }

        return response;
    }

    //Get All Finalized Orders
    public async Task<Response<TotalSalesDTO>> GetTotlaSales()
    {
        Response<TotalSalesDTO> response;

        try
        {

            await GetBearerToken();

            var data = await client.GetTotalSalesAsync();


            response = new Response<TotalSalesDTO>
            {
                Data = data,
                Success = true,
            };


        }

        catch (ApiException exception)
        {

            response = ConvertApiExceptions<TotalSalesDTO>(exception);

        }

        return response;
    }

    public async Task<Response<OrderDTO>> GetOrderByOrderId(int OrderId)
    {

        Response<OrderDTO> response;

        try
        {


            var data = await client.GetOrderByIdAsync(OrderId);


            response = new Response<OrderDTO>
            {
                Data = data,
                Success = true,
            };


        }

        catch (ApiException exception)
        {

            response = ConvertApiExceptions<OrderDTO>(exception);

        }

        return response;


    }

}
