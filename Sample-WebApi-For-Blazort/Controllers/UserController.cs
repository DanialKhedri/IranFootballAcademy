using Application.DTOs.Tokens;
using Application.DTOs.User.UserLogInDTO;
using Application.DTOs.User.UserReadOnlyDTO;
using Application.DTOs.User.UserRegisterDTO;
using Application.Services.Interface.User;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

namespace Sample_WebApi_For_Blazort.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    #region Ctor

    private readonly IUserService _userService;
    private readonly ILogger _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }


    #endregion


    // Get All Users
    //Just Admin
    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<UserReadonlyDTO>>> GetAllUsers()
    {
        //Admin Check
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userId));
        if (!isadmin)
            return Forbid();



        var Users = await _userService.GetAllUsers();


        return Ok(Users);

    }


    //Get User By Id
    //Just Admin
    [HttpGet("[Action]/{UserId}")]
    public async Task<ActionResult<List<UserReadonlyDTO>>> GetUserById(int UserId)
    {

        //Admin Check
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userId));
        if (!isadmin)
            return Forbid();


        var user = await _userService.GetUserById(UserId);

        if (user != null)
            return Ok(user);
        else
            return BadRequest();

    }


    //Register
    [HttpPost("[Action]")]
    public async Task<ActionResult> Register(UserRegisterDTO userRegisterDTO)
    {

        _logger.LogInformation(" Attempt Register: " + userRegisterDTO.PhoneNumber);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (userRegisterDTO == null)
            return BadRequest("UserDTO is Null");


        if (userRegisterDTO.Password == userRegisterDTO.RePassword)
        {

            if (!await _userService.IsPhoneNumberExist(userRegisterDTO.PhoneNumber)) //NotExist
            {
                if (await _userService.Register(userRegisterDTO))
                {
                    return Ok();
                }
                else
                {
                    _logger.LogError("Something Went Worong in Register");
                    return StatusCode(500);
                }

            }
            else
            {
                return BadRequest("Phone Number Already Exist");
            }


        }
        else
        {
            return BadRequest("Password And RePassword");
        }


    }


    //Log In
    [HttpPost("[Action]")]
    public async Task<ActionResult<UserResultLogInDTO?>> LogIn(UserLogInDTO userLogInDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var UserLogged = await _userService.LogIn(userLogInDTO);

        if (UserLogged == null)
        {
            UserResultLogInDTO result = new UserResultLogInDTO();
            result.FullName = "Empty";
            return Ok(result);

        }

        return Ok(UserLogged);

    }



    //RefreshToken
    [HttpPost("[Action]")]
    public async Task<ActionResult<AccessToken>> RefreshToken(string RefreshToken)
    {
        var AccessToken = await _userService.RefreshToken(RefreshToken);


        if (AccessToken == null)
        {
            return Unauthorized();
        }


        return Ok(AccessToken);
    }


    //User Is Admin
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> UserIsAdmin(int UserId)
    {
        var IsAdmin = await _userService.UserIsAdmin(UserId);

        return Ok(IsAdmin);
    }

    //Update UserAdmin
    //Just Admin
    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<bool>> UpdateUserAdminStatus(int userId, bool isAdmin)
    {
        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();



        var result = await _userService.UpdateUserAdminStatus(userId, isAdmin);

        return Ok(result);
    }


    //PhoneNumber Is Exist
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> PhoneNumberIsExist(string PhoneNumber)
    {
        var Result = await _userService.IsPhoneNumberExist(PhoneNumber);
        return Ok(Result);
    }

  



}
