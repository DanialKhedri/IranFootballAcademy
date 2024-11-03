using Application.DTOs.Course;
using Application.DTOs.Course.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface.Course;

public interface ICourseService
{
    public Task<List<CourseReadonlyDTO>> GetAllCourses();


    public Task<CourseReadonlyDTO?> GetCourseById(int CourseId);


    public Task<List<CourseReadonlyDTO>> GetCourseByUserId(int UserId);


    public Task<bool> AddCourse(AddCourseDTO coursedto);



    public Task<bool> EditCourse(EditCourseDTO coursedto, List<AddVideoDTO> Videos);


    public Task<bool> RemoveCourse(int CourseId);


    public Task<bool> BuyCourse(int CourseId, int UserId);



    public Task<bool> CourseIsBuyed(int UserId, int CourseId);

    public Task<List<CourseReadonlyDTO>> GetBuyedCoursesByUserId(int UserId);


}
