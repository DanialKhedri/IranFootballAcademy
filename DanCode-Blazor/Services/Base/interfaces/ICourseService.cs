namespace DanCode_Blazor.Services.Base.interfaces;

public interface ICourseService
{
    //Get All Courses
    public Task<Response<List<CourseReadonlyDTO>>> GetAllCourses();


    //Get Course By Id
    public Task<Response<CourseReadonlyDTO>> GetCourseById(int CourseId);


    //Get Courses By User Id 
    public Task<Response<List<CourseReadonlyDTO>>> GetCourseByUserId(int UserId);


    //Add Course
    public Task<Response<bool>> AddCourse(AddCourseDTO dto);


    //Edit Course 
    public Task<Response<bool>> EditCourse(EditCourseDTO editCourseDTO);

    //Remove
    public Task<Response<bool>> RemoveCourse(int CourseId);


    //Get Buyed Courses By User Id
    public Task<Response<List<CourseReadonlyDTO>>> GetBuyedCoursesByUserId(int UserId);

}
