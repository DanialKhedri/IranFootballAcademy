#region usings
using Application.DTOs.Order.Cart;
using Application.DTOs.Order.OrderDetailDTO;
using Application.DTOs.Order.OrderDTO;
using Application.DTOs.Order.TotalSales;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities.Order;
using Domain.Entities.Order.OrderDetail;
using Domain.Entities.Product;
using Domain.IRepository;
using Domain.IRepository.Product;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.Enums.Enums;
#endregion

namespace Application.Services.implements;

public class OrderService : IOrderService
{
    #region Ctor 

    private readonly IOrderRepository _orderrepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderrepository, IMapper mapper)
    {
        _orderrepository = orderrepository;
        _mapper = mapper;
    }

    #endregion


    //Client Side

    //Get Cart
    public async Task<Cart> GetCart(int userId)
    {
        // گرفتن سفارش باز برای کاربر
        var order = await _orderrepository.GetOpenOrderByUserId(userId);
        if (order == null)
            return null;

        // گرفتن جزئیات سفارش
        var orderDetails = await _orderrepository.GetOrderDetailsOfOrderByOrderId(order.Id);

        // ایجاد و مقداردهی به cart
        var cart = new Cart
        {
            Order = _mapper.Map<OrderDTO>(order),
            OrderDetailDTOs = orderDetails.Select(item => _mapper.Map<OrderDetailDTO>(item)).ToList()
        };

        return cart;
    }

    //Get Order By Id
    public async Task<OrderDTO?> GetOrderById(int OrderId)
    {



        var Order = await _orderrepository.GetOrderById(OrderId);

        if (Order == null) return null;

        var orderdto = _mapper.Map<OrderDTO>(Order);

        return orderdto;



    }

    //Add OrderDetail
    public async Task<bool> AddOrderDetail(int UserId, int ProductId, string itemType)
    {

        return await _orderrepository.AddOrderDetail(UserId, ProductId, itemType);


    }

    //Delete
    public async Task<bool> DeleteOrderDetail(int OrderDetailId)
    {

        return await _orderrepository.DeleteOrderDetail(OrderDetailId);

    }

    //FinalizeOrder
    public async Task<bool> FinalizeOrder(int? OrderId)
    {



        return await _orderrepository.FinalizeOrder(OrderId);
    }

    //Get OrderDetail By Order ID
    public async Task<List<OrderDetailDTO>> GetOrderDetailsByOrderId(int OrderId)
    {

        var orderDetails = await _orderrepository.GetOrderDetailsByOrderId(OrderId);

        List<OrderDetailDTO> orderDetailDTOs = new List<OrderDetailDTO>();

        if (orderDetails != null || orderDetails.Count != 0)
        {

            foreach (var item in orderDetails)
            {
                var temp = _mapper.Map<OrderDetailDTO>(item);
                orderDetailDTOs.Add(temp);
            }

        }

        return orderDetailDTOs;


    }


    //Admin Side

    public async Task<List<OrderDTO>> GetAllFinalizedOrder()
    {
        var Orders = await _orderrepository.GetAllFinalizedOrders();
        List<OrderDTO> orderDTOs = new List<OrderDTO>();

        if (Orders != null)
        {
            foreach (var item in Orders)
            {
                var temp = _mapper.Map<OrderDTO>(item);
                orderDTOs.Add(temp);

            }

            return orderDTOs;
        }
        else
            return
                orderDTOs;
    }

    public async Task<List<OrderDTO>> GetLastFiveOrders()
    {
        var Orders = await _orderrepository.GetLastFiveOrders();
        List<OrderDTO> orderDTOs = new List<OrderDTO>();

        if (Orders != null)
        {
            foreach (var item in Orders)
            {
                var temp = _mapper.Map<OrderDTO>(item);
                orderDTOs.Add(temp);

            }

            return orderDTOs;
        }
        else
            return
                orderDTOs;
    }

    public async Task<TotalSalesDTO> GetTotalSales()
    {

        var orders = await _orderrepository.GetAllFinalizedOrders();

        var totalSales = new TotalSalesDTO
        {
            Count = orders?.Count ?? 0,
            Sum = orders?.Sum(o => o.Sum) ?? 0
        };

        return totalSales;
    }



    public async Task<List<OrderDTO>> GetFinalizedOrdersByUserId(int UserId)
    {


        var Orders = await _orderrepository.GetFinalizedOrdersByUserId(UserId);

        List<OrderDTO> orderDTOs = new List<OrderDTO>();

        if (Orders != null)
        {
            foreach (var item in Orders)
            {

                var temp = _mapper.Map<OrderDTO>(item);
                orderDTOs.Add(temp);
            }

            return orderDTOs;

        }


        else
        {
            return null;
        }


    }

}
