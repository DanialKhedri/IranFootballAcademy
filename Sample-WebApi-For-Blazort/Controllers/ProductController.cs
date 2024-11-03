using Application.DTOs.Product.ProductDTO;
using Application.Services.Implement.Product;
using Application.Services.Interface.Product;
using Application.Services.Interface.User;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sample_WebApi_For_Blazort.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    #region Ctor
    private readonly IProductService _productService;
    private readonly IUserService _userService;
    public ProductController(IProductService productService, IUserService userService)
    {
        _productService = productService;
        _userService = userService;
    }
    #endregion


    //Get All Products
    [HttpGet("[action]")]
    public async Task<ActionResult<List<ProductReadOnlyDTO>>> GetAllProducuts()
    {


        var Products = await _productService.GetAllProducuts();

        if (Products != null)
        {
            return Ok(Products);
        }
        else

            return BadRequest();

    }


    //Get Product By Id
    [HttpGet("[action]/{ProductId}")]
    public async Task<ActionResult<ProductReadOnlyDTO>> GetProductById(int ProductId)
    {

        var productdto = await _productService.GetProductById(ProductId);
        return productdto;

    }





    //Create Product
    //just admin
    [Authorize]
    [HttpPost("[action]")]
    public async Task<ActionResult<bool>> CreateProduct(CreateProductDTO createproductDTO)
    {
        //Admin Check
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userId));
        if (!isadmin)
            return Forbid();


        if (!ModelState.IsValid)
            return BadRequest();



        if (createproductDTO != null)
        {
            var result = await _productService.CreateProduct(createproductDTO);


            return Ok(result);



        }
        else
            return BadRequest();

    }


    //Update Product
    //just admin
    [Authorize]
    [HttpPatch("[action]")]
    public async Task<ActionResult<bool>> UpdateProduct(ProductDTO productDTO)
    {

        //Admin Check
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userId));
        if (!isadmin)
            return Forbid();

        if (!ModelState.IsValid)
            return BadRequest();


        if (productDTO != null)
        {
            var result = await _productService.UpdateProduct(productDTO);
            return Ok(result);



        }
        else
            return BadRequest();
    }


    //Delete Product
    //just admin
    [Authorize]
    [HttpPost("[action]/{ProductId}")]
    public async Task<ActionResult<bool>> DeleteProduct(int ProductId)
    {

        //Admin Check
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userId));
        if (!isadmin)
            return Forbid();

        if (!ModelState.IsValid)
            return BadRequest();


        var result = await _productService.DeleteProduct(ProductId);

        return Ok(result);



    }


    //Product is Buyed
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> ProductIsBuyed(int UserId, int ProductId)
    {

        var result = await _productService.ProductIsBuyed(UserId, ProductId);

        return Ok(result);

    }




    //Get Buyed Products By UserId

    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<ProductReadOnlyDTO>>> GetBuyedProductsByUserId(int UserId)
    {

        // بررسی اینکه آیا UserId معتبر است
        if (UserId <= 0)
        {
            return BadRequest("Invalid User ID.");
        }

        // گرفتن محصولات خریداری شده از سرویس
        var products = await _productService.GetBuyedProductsByUserId(UserId);

   

        // بازگرداندن لیست محصولات با وضعیت 200 OK
        return Ok(products);
    }




}







