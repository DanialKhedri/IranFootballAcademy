using Blazored.LocalStorage;
using DanCode_Blazor.Services.Base;
using DanCode_Blazor.Services.Base.interfaces;

namespace DanCode_Blazor.Services.CourseService;

public class CourseService : BaseHttpService, ICourseService
{

    #region Ctor

    private readonly IClient client;
    public CourseService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {
        this.client = client;
    }

    #endregion


    #region Course

    //Get All Courses
    public async Task<Response<List<CourseReadonlyDTO>>> GetAllCourses()
    {


        Response<List<CourseReadonlyDTO>> response;

        try
        {
            var data = await client.GetAllCoursesAsync();


            response = new Response<List<CourseReadonlyDTO>>
            {
                Data = data.ToList(),
                Success = true,
            };
        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<List<CourseReadonlyDTO>>(exception);

        }

        return response;

    }


    //Get Course By Id
    public async Task<Response<CourseReadonlyDTO>> GetCourseById(int CourseId)
    {

        Response<CourseReadonlyDTO> response;
        try
        {


            var data = await client.GetCourseByIdAsync(CourseId);

            response = new Response<CourseReadonlyDTO>
            {
                Data = data,

                Success = true,

            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<CourseReadonlyDTO>(exception);

        }

        return response;

    }



    //Get Courses By User Id 
    public async Task<Response<List<CourseReadonlyDTO>>> GetCourseByUserId(int UserId)
    {


        Response<List<CourseReadonlyDTO>> response;
        try
        {


            var data = await client.GetCoursesByUserIdAsync(UserId);



            response = new Response<List<CourseReadonlyDTO>>
            {
                Data = data.ToList(),

                Success = true,

            };


        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<List<CourseReadonlyDTO>>(exception);

        }

        return response;



    }


    //Add Course
    public async Task<Response<bool>> AddCourse(AddCourseDTO dto)
    {

        Response<bool> response;

        try
        {

            await GetBearerToken();
            var data = await client.AddCourseAsync(dto);


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



    //Edit Course 
    public async Task<Response<bool>> EditCourse(EditCourseDTO editCourseDTO)
    {

        Response<bool> response;

        try
        {

            await GetBearerToken();
            var data = await client.EditCourseAsync(editCourseDTO);


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



    //Remove Course 
    public async Task<Response<bool>> RemoveCourse(int CourseId)
    {
        Response<bool> response;

        try
        {

            await GetBearerToken();
            var data = await client.RemoveCourseAsync(CourseId);


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



    //Get Buyed Courses By User Id
    public async Task<Response<List<CourseReadonlyDTO>>> GetBuyedCoursesByUserId(int UserId)
    {

        Response<List<CourseReadonlyDTO>> response;

        try
        {

           await GetBearerToken();
            var data = await client.GetBuyedCoursesByUserIdAsync(UserId);


            response = new Response<List<CourseReadonlyDTO>>
            {
                Data = data.ToList(),
                Success = true,
            };
        }
        catch (ApiException exception)
        {

            response = ConvertApiExceptions<List<CourseReadonlyDTO>>(exception);

        }

        return response;

    }

    #endregion



}
