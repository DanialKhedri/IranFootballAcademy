#region usings
using Application.DTOs.Course;
using Domain.Entities.Course;
using Domain.IRepository.Course;
using Infrastructure.Data;
using Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Infrastructure.Repository.Course;

public class CourseRepository : ICourseRepository
{

    #region Ctor

    private readonly DataContext _dataContext;

    public CourseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    #endregion


    //Get All Courses
    public async Task<List<Domain.Entities.Course.Course>> GetAllCourses()
    {

        try
        {
            return await _dataContext.Courses.Where(c => c.IsDelete == false).ToListAsync();

        }
        catch
        {

            return null;
        }

    }


    //Get Course By Id
    public async Task<Domain.Entities.Course.Course?> GetCourseById(int CourseId)
    {

        try
        {
            var Course = await _dataContext.Courses.FirstOrDefaultAsync(c => c.Id == CourseId && c.IsDelete == false);

            if (Course != null)
                Course.Videos = await _dataContext.Videos.Where(v => v.CourseId == Course.Id).ToListAsync();


            return Course;
        }
        catch
        {
            return null;
        }



    }


    //Get Courses By User Id ==> Buyed Course
    public async Task<List<Domain.Entities.Course.Course>> GetCourseByUserId(int UserId)
    {

        try
        {
            return await _dataContext.BuyedCourses.Where(b => b.UserId == UserId)
                                                  .Select(b => b.Course)
                                                  .ToListAsync();

        }
        catch
        {

            return null;

        }


    }


    //Add Course 
    public async Task<bool> AddCourse(Domain.Entities.Course.Course course, List<Video> Videos)
    {

        try
        {
            if (course != null)
            {

                var IsExist = await _dataContext.Courses.AnyAsync(c => c.Title == course.Title);

                if (IsExist)
                    return false;



                await _dataContext.Courses.AddAsync(course);
                await _dataContext.SaveChangesAsync();

                if (Videos != null)
                {
                    var temp = await _dataContext.Courses.FirstOrDefaultAsync(c => c.Title == course.Title);

                    foreach (var item in Videos)
                    {

                        Video video = new Video()
                        {

                            CourseId = temp.Id,
                            VideoUrl = item.VideoUrl,
                            Order = item.Order,
                            Title = item.Title,
                        };

                        _dataContext.Videos.Add(video);

                    }
                    await _dataContext.SaveChangesAsync();

                }





                return true;
            }
            else
                return false;
        }
        catch
        {

            return false;
        }

    }


    //Edit Course
    public async Task<bool> EditCourse(Domain.Entities.Course.Course course, List<Video> Videos)
    {
        try
        {
            if (course != null)
            {
                var OriginCourse = await _dataContext.Courses
                                         .FirstOrDefaultAsync(c => c.Id == course.Id);


                OriginCourse.Author = course.Author;
                OriginCourse.Title = course.Title;
                OriginCourse.Description = course.Description;
                OriginCourse.Time = course.Time;
                OriginCourse.Price = course.Price;
                OriginCourse.WhyUs = course.WhyUs;


                if (OriginCourse.ImageUrl != null)
                    OriginCourse.ImageUrl = course.ImageUrl;

                _dataContext.Courses.Update(OriginCourse);

                if (Videos != null)
                {
                    //Delete Last Videos of Course
                    var LastVideos = await _dataContext.Videos
                              .Where(v => v.CourseId == OriginCourse.Id)
                              .ToListAsync();

                    _dataContext.Videos.RemoveRange(LastVideos);

                    //Add new Videos
                    foreach (var item in Videos)
                    {


                        Video video = new Video()
                        {
                            CourseId = OriginCourse.Id,
                            VideoUrl = item.VideoUrl,
                            Order = item.Order,
                            Title = item.Title,
                        };

                        await _dataContext.Videos.AddAsync(video);

                    }





                }

                await _dataContext.SaveChangesAsync();

                return true;

            }
            else
                return false;

        }
        catch
        {
            return false;

        }


    }


    //Remove Course
    public async Task<bool> RemoveCourse(int CourseId)
    {

        try
        {
            var Course = await _dataContext.Courses
                                           .FirstOrDefaultAsync(c => c.Id == CourseId && c.IsDelete == false);

            if (Course == null)
                return false;



            _dataContext.Courses.Remove(Course);

            var vids = await _dataContext.Videos.Where(v => v.CourseId == CourseId).ToListAsync();

            if (vids != null)
            {
                _dataContext.Videos.RemoveRange(vids);
            }

            await _dataContext.SaveChangesAsync();

            return true;



        }
        catch
        {

            throw;
        }
    }


    //Buy Course 
    public async Task<bool> BuyCourse(int CourseId, int UserId)
    {


        try
        {

            BuyedCourse buyedCourse = new BuyedCourse()
            {
                CourseId = CourseId,
                UserId = UserId,
                DateBuyed = DateTime.Now,

            };

            _dataContext.BuyedCourses.Add(buyedCourse);
            await _dataContext.SaveChangesAsync();

            return true;
        }
        catch
        {

            return false;
        }

    }


    //Course Is Buyed
    public async Task<bool> CourseIsBuyed(int UserId, int CourseId)
    {
        try
        {
            var IsBuyed = _dataContext.BuyedCourses.Any(c => c.UserId == UserId && c.CourseId == CourseId);
            return IsBuyed;
        }
        catch
        {

            return false;
        }

    }

    //Get Buyed Courses By User Id
    public async Task<List<Domain.Entities.Course.Course>> GetBuyedCoursesByUserId(int UserId)
    {
        try
        {

            var Courses = await _dataContext.BuyedCourses.Where(c => c.UserId == UserId)
                                       .Select(c => c.Course).ToListAsync();

            return Courses;

        }
        catch
        {

            return null;
        }
    }


}
