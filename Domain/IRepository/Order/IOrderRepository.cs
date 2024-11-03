#region usings
using Domain.Entities.Order;
using Domain.Entities.Order.OrderDetail;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Enums.Enums;
#endregion
namespace Domain.IRepository;

public interface IOrderRepository
{

    //Gets

    //Cart
    public Task<Order?> GetOpenOrderByUserId(int UserId);
    public Task<List<OrderDetail>> GetOrderDetailsOfOrderByOrderId(int OrderId);

    //Get Order By Id
    public Task<Order?> GetOrderById(int OrderId);


    //Add-Delete-Finalize
    public Task<bool> AddOrderDetail(int UserId, int ProductId, string itemType);
    public Task<bool> DeleteOrderDetail(int OrderDetailId);
    public Task<bool> FinalizeOrder(int? orderId);





    // Shared
    public Task<List<Order>> GetFinalizedOrdersByUserId(int UserId);

    public Task<List<OrderDetail>> GetOrderDetailsByOrderId(int OrderId);



    //Admin Side

    public Task<List<Order>> GetAllFinalizedOrders();

    public Task<List<Order>> GetLastFiveOrders();



}
