#region usings
using Application.DTOs.Course;
using Application.Services.Interface.Course;
using Application.Services.Interface.User;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
#endregion

namespace Sample_WebApi_For_Blazort.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{

    #region Ctor

    private readonly ICourseService _courseService;
    private readonly IUserService _userService;

    public CourseController(ICourseService courseService, IUserService userService)
    {
        _courseService = courseService;
        _userService = userService;
    }


    #endregion


    //Get All Courses


    [HttpGet("[Action]")]
    public async Task<ActionResult<List<CourseReadonlyDTO>>> GetAllCourses()
    {



        var Courses = await _courseService.GetAllCourses();

        return Ok(Courses);
    }


    //Get Course By Id
    [HttpGet("[Action]/{CourseId:int}")]
    public async Task<ActionResult<CourseReadonlyDTO>> GetCourseById(int CourseId)
    {

        var Course = await _courseService.GetCourseById(CourseId);


        if (Course == null)
            return BadRequest();


        return Ok(Course);




    }


    //Get Courses By User Id
    [Authorize]
    [HttpGet("[Action]/{UserId:int}")]
    public async Task<ActionResult<List<CourseReadonlyDTO>>> GetCoursesByUserId(int UserId)
    {

        var Courses = await _courseService.GetCourseByUserId(UserId);
        return Ok(Courses);


    }


    //Add Course
    //Just Admin
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> AddCourse(AddCourseDTO dto)
    {
        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();



        var result = await _courseService.AddCourse(dto);

        return Ok(result);


    }


    //Edit Course
    [Authorize]
    [HttpPatch("[Action]")]
    public async Task<ActionResult<bool>> EditCourse(EditCourseDTO dto)
    {

        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();

        var result = await _courseService.EditCourse(dto, dto.videos);
        return Ok(result);

    }


    //Remove Course
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> RemoveCourse(int CourseId)
    {
        //Admin Check
        var userIid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIid == null)
            return Forbid();

        var isadmin = await _userService.UserIsAdmin(int.Parse(userIid));
        if (!isadmin)
            return Forbid();

        var result = await _courseService.RemoveCourse(CourseId);
        return Ok(result);

    }


    //Buy Course
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> BuyCourse(int CourseId, int UserId)
    {
        var result = await _courseService.BuyCourse(CourseId, UserId);
        return Ok(result);
    }


    //Course is Buyed
    [Authorize]
    [HttpPost("[Action]")]
    public async Task<ActionResult<bool>> CourseIsBuyed(int UserId, int CourseId)
    {


        var result = await _courseService.CourseIsBuyed(UserId, CourseId);

        return Ok(result);

    }


    //GetBuyedCoursesByUserId
    [Authorize]
    [HttpGet("[Action]")]
    public async Task<ActionResult<List<CourseReadonlyDTO>>> GetBuyedCoursesByUserId(int UserId)
    {

        // بررسی اینکه آیا UserId معتبر است
        if (UserId <= 0)
        {
            return BadRequest("Invalid User ID.");
        }

        // گرفتن محصولات خریداری شده از سرویس
        var Courses = await _courseService.GetBuyedCoursesByUserId(UserId);



        // بازگرداندن لیست محصولات با وضعیت 200 OK
        return Ok(Courses);

    }


}
