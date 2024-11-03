#region usings
using Domain.Entities.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.IRepository.Course;

public interface ICourseRepository
{

    public Task<List<Domain.Entities.Course.Course>> GetAllCourses();


    public Task<Domain.Entities.Course.Course?> GetCourseById(int CourseId);


    public Task<List<Domain.Entities.Course.Course>> GetCourseByUserId(int UserId);


    public Task<bool> AddCourse(Domain.Entities.Course.Course course, List<Video> Videos);


    public Task<bool> EditCourse(Domain.Entities.Course.Course course, List<Video> Videos);


    public Task<bool> RemoveCourse(int CourseId);


    public Task<bool> BuyCourse(int CourseId, int UserId);


    public Task<bool> CourseIsBuyed(int UserId, int CourseId);

    public Task<List<Domain.Entities.Course.Course>> GetBuyedCoursesByUserId(int UserId);

}
