using Application.DTOs.Order.Cart;
using Application.DTOs.Order.OrderDetailDTO;
using Application.DTOs.Order.OrderDTO;
using Application.DTOs.Order.TotalSales;
using Application.Services.Interface;
using Application.Services.Interface.User;
using Application.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Domain.Entities.Enums.Enums;

namespace Sample_WebApi_For_Blazort.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{

    #region Ctor

    private readonly IOrderService _orderService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public OrderController(IOrderService orderService, IMapper mapper, IUserService userService)
    {
        _orderService = orderService;
        _mapper = mapper;
        _userService = userService;
    }


    #endregion


    #region User Side
    //User Side

    [HttpGet("[Action]")]
    public async Task<ActionResult<OrderDTO?>> GetOrderById(int OrderID)
    {

        return await _orderService.GetOrderById(OrderID);

    }


    //Get Cart
    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<Cart>> GetCart(int UserID)
    {

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (UserID != int.Parse(userIdClaim))
        {
            return BadRequest();
        }

        var Cart = await _orderService.GetCart(UserID);

        return Ok(Cart);


    }


    //Add Product OrderDetail To Order
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> AddProductToCart(int UserId, int ProductId)
    {

        return await _orderService.AddOrderDetail(UserId, ProductId, "Product");

    }

    //Add Course OrderDetail To Order
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> AddCourseToCart(int UserId, int CourseID)
    {

        var result = await _orderService.AddOrderDetail(UserId, CourseID, "Course");

        return Ok(result);

    }

    //Delete OrderDetail From Order
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> DeleteOrderDetailFromOrder(int OrderDetailId)
    {
        return await _orderService.DeleteOrderDetail(OrderDetailId);
    }

    //Finalize Order 
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> FinalizeOrder(int OrderId, int UserId)
    {
        return await _orderService.FinalizeOrder(OrderId);
    }


    #endregion



    #region AdminSide
    //AdminSide


    //Get All Finalized Order

    //Just Admin
    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<OrderDTO>>> GetAllFinalizedOrder()
    {
        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();

        var Orders = await _orderService.GetAllFinalizedOrder();

        return Ok(Orders);

    }


    //Get Last 5 Order
    //just admin
    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<OrderDTO>>> GetLastFiveOrder()
    {

        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();

        var Orders = await _orderService.GetLastFiveOrders();

        return Ok(Orders);

    }

    //just admin
    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<TotalSalesDTO>> GetTotalSales()
    {
        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();

        var Totalsales = await _orderService.GetTotalSales();

        return Ok(Totalsales);
    }

    #endregion


    #region Shared

    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<OrderDTO>>> GetFinalizedOrdersByUserId(int UserId)
    {


        if (UserId <= 0)
        {
            return BadRequest();
        }



        var Orders = await _orderService.GetFinalizedOrdersByUserId(UserId);

        return Ok(Orders);


    }


    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<OrderDetailDTO>>> GetOrderDetailsByOrderId(int OrderId)
    {

        if (OrderId <= 0)
            return BadRequest();


        var orderdetials = await _orderService.GetOrderDetailsByOrderId(OrderId);

        return Ok(orderdetials);

    }


    #endregion

}
