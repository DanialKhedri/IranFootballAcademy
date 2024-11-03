#region Ctor
using Application.DTOs.Order.OrderDTO;
using Domain.Entities.Course;
using Domain.Entities.Order;
using Domain.Entities.Order.OrderDetail;
using Domain.Entities.Payment;
using Domain.Entities.Product;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Enums.Enums;
#endregion

namespace Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{
    #region Ctor

    private readonly DataContext _datacontext;

    public OrderRepository(DataContext datacontext)
    {
        _datacontext = datacontext;
    }

    #endregion



    #region Client Side

    //Cart
    public async Task<Order?> GetOpenOrderByUserId(int UserId)
    {

        return await _datacontext.Orders.FirstOrDefaultAsync(o => o.UserId == UserId && o.IsDelete == false && o.IsFinaly == false);
    }
    public async Task<List<OrderDetail>> GetOrderDetailsOfOrderByOrderId(int orderId)
    {
        // واکشی جزئیات سفارش برای سفارش خاصی که حذف نشده است
        var orderDetails = await _datacontext.OrderDetails
            .Where(od => od.OrderId == orderId && od.Order.IsDelete == false)
            .ToListAsync();

        return orderDetails;
    }

    //Get Order By Id

    public async Task<Order?> GetOrderById(int OrderId)
    {


        try
        {

            return await _datacontext.Orders.FirstOrDefaultAsync(o => o.Id == OrderId && o.IsDelete == false);
        }
        catch
        {

            return null;
        }

    }

    //Add-Delete-Finalize
    public async Task<bool> AddOrderDetail(int UserId, int ItemId, string itemType)
    {


        var order = await _datacontext.Orders.FirstOrDefaultAsync(o => o.UserId == UserId && o.IsFinaly == false && o.IsDelete == false);

        //  if order is exist
        if (order != null)
        {
            //Add OrderDetail

            try
            {
                await AddOd(order.Id, ItemId, itemType);
                return true;
            }
            catch
            {

                return false;
            }

        }

        // If Order Is Not Exist

        else
        {
            // Create Order For User

            try
            {
                Order order1 = new Order()
                {
                    UserId = UserId,

                };

                await _datacontext.Orders.AddAsync(order1);
                await _datacontext.SaveChangesAsync();
            }
            catch
            {

                return false;
            }




            //add Order Detail to Order

            try
            {
                var order2 = _datacontext.Orders.FirstOrDefaultAsync(o => o.UserId == UserId && o.IsFinaly == false);

                var result = await AddOd(order2.Id, ItemId, itemType);


                return result;
            }
            catch
            {

                return false;
            }


        }


    }

    public async Task<bool> DeleteOrderDetail(int orderDetailId)
    {
        var orderDetail = await _datacontext.OrderDetails.FindAsync(orderDetailId);

        if (orderDetail == null)
            return false;

        try
        {
            // حذف OrderDetail
            _datacontext.OrderDetails.Remove(orderDetail);
            await _datacontext.SaveChangesAsync();

            //Update Sum
            await UpdateSum(orderDetail.OrderId);

            // بررسی اینکه آیا سفارش خالی است و در صورت لزوم حذف آن
            bool isOrderEmpty = !await _datacontext.OrderDetails.AnyAsync(od => od.OrderId == orderDetail.OrderId);

            if (isOrderEmpty)
            {
                var order = await _datacontext.Orders.FindAsync(orderDetail.OrderId);
                if (order != null)
                {
                    _datacontext.Orders.Remove(order);
                    await _datacontext.SaveChangesAsync();
                }
            }



            return true;
        }
        catch
        {
            return false;
        }
    }


    public async Task<bool> FinalizeOrder(int? orderId)
    {
        try
        {
            // واکشی سفارش با توجه به شناسه
            var order = await _datacontext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            // اگر سفارش وجود داشت، آن را نهایی کنید
            if (order == null)
                return false;

            order.IsFinaly = true;
            _datacontext.Orders.Update(order);

            //Buyed Course  and Buyed Products
            var Orderdetails = await _datacontext.OrderDetails
                .Where(o => o.OrderId == orderId)
                .ToListAsync();


            foreach (var item in Orderdetails)
            {

                if (item.ItemType == "Course")
                {

                    BuyedCourse buyedCourse = new BuyedCourse()
                    {
                        CourseId = item.ItemId,
                        DateBuyed = DateTime.Now,
                        UserId = order.UserId,
                    };

                    await _datacontext.BuyedCourses.AddAsync(buyedCourse);
                }

                else if (item.ItemType == "Product")
                {

                    //Add Buyed Product
                    BuyedProduct buyedProducts = new BuyedProduct()
                    {
                        ProductId = item.ItemId,
                        DateBuyed = DateTime.Now,
                        UserId = order.UserId,
                    };

                    await _datacontext.BuyedProducts.AddAsync(buyedProducts);
                }


            }


            //Add Payment
            Domain.Entities.Payment.Payment payment = new Domain.Entities.Payment.Payment()
            {
                Amount = order.Sum,
                OrderId = orderId.GetValueOrDefault(),
                UserId = order.UserId,
                Date = DateTime.Now,

            };
            await _datacontext.Payments.AddAsync(payment);


            //savechange
            await _datacontext.SaveChangesAsync();


            return true;
        }
        catch
        {
            // در صورت بروز خطا، بازگشت false
            return false;
        }
    }

    #endregion


    #region Admin Side

    public async Task<List<Order>> GetAllFinalizedOrders()
    {


        try
        {
            var orders = await _datacontext.Orders.Where(o => o.IsFinaly == true && o.IsDelete == false)
                                                       .OrderBy(o => o.CreateTime)
                                                       .ToListAsync();

            return orders;

        }
        catch
        {

            return null;
        }

    }


    //Take Last 5
    public async Task<List<Order>> GetLastFiveOrders()
    {
        var orders = await _datacontext.Orders
                                       .Where(o => o.IsFinaly == true && o.IsDelete == true)
                                       .OrderByDescending(o => o.CreateTime) // مرتب‌سازی به صورت نزولی
                                       .Take(5)
                                       .ToListAsync();

        return orders;
    }




    #endregion


    #region Shared

    //Get Finalized Orders By UserId
    public async Task<List<Order>> GetFinalizedOrdersByUserId(int UserId)
    {
        try
        {
            var Orders = await _datacontext.Orders
            .Where(o => o.UserId == UserId && o.IsFinaly == true)
            .ToListAsync();

            return Orders;
        }
        catch
        {
            return null;
        }


    }


    //Get OrderDetails By Order Id
    public async Task<List<OrderDetail>> GetOrderDetailsByOrderId(int OrderId)
    {

        try
        {

            var orderdetails = await _datacontext.OrderDetails
                .Where(o => o.OrderId == OrderId)
                .ToListAsync();


            return orderdetails;
        }
        catch
        {

            return null;
        }

    }

    #endregion










    // Private Methods

    public async Task<bool> AddOd(int OrderId, int ItemId, string itemType)
    {
        int Price = 0;
        string Title = string.Empty;

        var Item = itemType switch
        {
            "Product" => await _datacontext.Products.FirstOrDefaultAsync(p => p.Id == ItemId) as object,
            "Course" => await _datacontext.Courses.FirstOrDefaultAsync(c => c.Id == ItemId) as object,
            _ => null
        };

        if (Item == null)
            return false;

        if (itemType == "Product")
        {
            var product = (Domain.Entities.Product.Product)Item;
            Price = ((Domain.Entities.Product.Product)Item).Price;
            Title = ((Domain.Entities.Product.Product)Item).Name;
        }
        else if (itemType == "Course")
        {
            var course = (Domain.Entities.Course.Course)Item;
            Price = course.Price;
            Title = course.Title;
        }

        try
        {
            var orderDetail = new OrderDetail
            {
                OrderId = OrderId,
                ItemId = ItemId,
                ItemType = itemType,
                Price = Price,
                Title = Title,
            };

            await _datacontext.OrderDetails.AddAsync(orderDetail);
            await _datacontext.SaveChangesAsync();

            await UpdateSum(OrderId);
            return true;

        }
        catch (Exception ex)
        {
            // Log exception if necessary
            return false;
        }
    }


    private async Task<bool> UpdateSum(int orderId)
    {


        try
        {
            var order = await _datacontext.Orders
                     .Where(o => o.Id == orderId)
                     .Select(o => new
                     {
                         Order = o,
                         Sum = _datacontext.OrderDetails
                                 .Where(od => od.OrderId == orderId)
                                 .Sum(od => od.Price)
                     })
                     .FirstOrDefaultAsync();

            if (order == null)
            {
                return false;
            }

            order.Order.Sum = order.Sum;


            _datacontext.Orders.Update(order.Order);
            await _datacontext.SaveChangesAsync();

            return true;
        }
        catch
        {

            return false;
        }


    }




}
