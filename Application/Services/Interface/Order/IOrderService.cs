
#region Usings
using Application.DTOs.Product.ProductDTO;
using Application.DTOs.Order.OrderDetailDTO;
using Application.DTOs.Order.OrderDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepository;
using Domain.Entities.Order.OrderDetail;
using Domain.Entities.Order;
using Application.DTOs.Order.Cart;
using static Domain.Entities.Enums.Enums;
using Application.DTOs.Order.TotalSales;
#endregion

namespace Application.Services.Interfaces;

public interface IOrderService
{

    //Client Side
    public Task<Cart> GetCart(int UserId);



    //Get Order By Id
    public Task<OrderDTO?> GetOrderById(int OrderId);

    //Add-Delete-Finalize
    public Task<bool> AddOrderDetail(int UserId, int ProductId, string itemType);
    public Task<bool> DeleteOrderDetail(int OrderDetailId);
    public Task<bool> FinalizeOrder(int? OrderId);


    public Task<List<OrderDetailDTO>> GetOrderDetailsByOrderId(int OrderId);


    //Admin Side
    public Task<List<OrderDTO>> GetAllFinalizedOrder();
    public Task<List<OrderDTO>> GetLastFiveOrders();
    public Task<TotalSalesDTO> GetTotalSales();


    public Task<List<OrderDTO>> GetFinalizedOrdersByUserId(int UserId);

}
