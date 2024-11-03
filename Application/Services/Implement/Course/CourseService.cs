#region usings
using Application.DTOs.Course;
using Application.DTOs.Course.Video;
using Application.Services.Interface.Course;
using AutoMapper;
using Domain.Entities.Course;
using Domain.IRepository.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion




namespace Application.Services.Implement.Course;

public class CourseService : ICourseService
{

    #region Ctor

    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    #endregion

    //Get All Courses
    public async Task<List<CourseReadonlyDTO>> GetAllCourses()
    {

        var Courses = await _courseRepository.GetAllCourses();

        List<CourseReadonlyDTO> courseReadonlyDTOs = new List<CourseReadonlyDTO>();

        if (Courses != null)
        {
            foreach (var course in Courses)
            {

                var dto = _mapper.Map<CourseReadonlyDTO>(course);

                courseReadonlyDTOs.Add(dto);

            }
        }

        return courseReadonlyDTOs;
    }


    //Get Course By Id
    public async Task<CourseReadonlyDTO?> GetCourseById(int CourseId)
    {
        var Course = await _courseRepository.GetCourseById(CourseId);


        if (Course != null)
        {

            CourseReadonlyDTO dto = new CourseReadonlyDTO()
            {
                Id = Course.Id,
                Author = Course.Author,
                Description = Course.Description,
                Title = Course.Title,
                Time = Course.Time,
                ImageUrl = Course.ImageUrl,
                Price = Course.Price,
                For = Course.For,
                WhyUs = Course.WhyUs,
                
            };

            if (Course.Videos != null && Course?.Videos?.Count > 0)
            {
                foreach (var item in Course.Videos)
                {
                    ReadOnlyVideoDTO videoDTO = new ReadOnlyVideoDTO()
                    {
                        Order = item.Order,
                        VideoUrl = item.VideoUrl,
                        Title = item.Title,
                    };

                    dto.Videos.Add(videoDTO);

                }

            }

            return dto;

        }
        else
        { return null; }

    }


    //Get Courses By User Id ==> Buyed Course
    public async Task<List<CourseReadonlyDTO>> GetCourseByUserId(int UserId)
    {

        var Courses = await _courseRepository.GetCourseByUserId(UserId);
        List<CourseReadonlyDTO> courseReadonlyDTOs = new List<CourseReadonlyDTO>();

        if (Courses != null)
        {

            foreach (var course in Courses)
            {
                var dto = _mapper.Map<CourseReadonlyDTO>(course);
                courseReadonlyDTOs.Add(dto);
            }

        }

        return courseReadonlyDTOs;

    }


    //Add Course 
    public async Task<bool> AddCourse(AddCourseDTO coursedto)
    {

        if (coursedto == null)
            return false;

        Domain.Entities.Course.Course OriginCourse = new Domain.Entities.Course.Course()
        {

            Author = coursedto.Author,
            Description = coursedto.Description,
            Title = coursedto.Title,
            Time = coursedto.Time,
            ImageUrl = coursedto.ImageUrl,
            Price = coursedto.Price,
            For = coursedto.For,
            WhyUs = coursedto.WhyUs,

        };

        List<Video> vids = new List<Video>();

        if (coursedto.videos != null)
        {

            foreach (var video in coursedto.videos)
            {
                Video vid = new Video
                {

                    Order = video.Order,
                    VideoUrl = video.VideoUrl,
                    Title = video.Title,

                };

                vids.Add(vid);
            }

        }




        return await _courseRepository.AddCourse(OriginCourse, vids);

    }


    //Edit Course
    public async Task<bool> EditCourse(EditCourseDTO coursedto, List<AddVideoDTO> Videos)
    {


        if (coursedto == null)
            return false;



        Domain.Entities.Course.Course course = new Domain.Entities.Course.Course()
        {

            Id = coursedto.Id,
            Author = coursedto.Author,
            Description = coursedto.Description,
            Time = coursedto.Time,
            Title = coursedto.Title,
            ImageUrl = coursedto.ImageUrl,
            Price = coursedto.Price,
            For = coursedto.For,
            WhyUs = coursedto.WhyUs,

        };


        List<Video> vids = new List<Video>();



        if (Videos.Count != 0 && Videos != null)
        {

            foreach (var item in Videos)
            {

                Video vid = new Video()
                {
                    VideoUrl = item.VideoUrl,
                    Order = item.Order,
                    Title = item.Title,
                };

                vids.Add(vid);

            }
        }

        return await _courseRepository.EditCourse(course, vids);


    }


    //Remove Course
    public async Task<bool> RemoveCourse(int CourseId)
    {

        return await _courseRepository.RemoveCourse(CourseId);

    }


    //Buy Course 
    public async Task<bool> BuyCourse(int CourseId, int UserId)
    {

        return await _courseRepository.BuyCourse(CourseId, UserId);


    }


    //Course Is Buyed?
    public async Task<bool> CourseIsBuyed(int UserId, int CourseId)
    {

        return await _courseRepository.CourseIsBuyed(UserId, CourseId);

    }

    //Get Buyed Courses By User Id
    public async Task<List<CourseReadonlyDTO>> GetBuyedCoursesByUserId(int UserId)
    {

        var Courses = await _courseRepository.GetBuyedCoursesByUserId(UserId);

        List<CourseReadonlyDTO> courseReadonlyDTOs = new List<CourseReadonlyDTO>();

        if (Courses != null)
        {

            foreach (var item in Courses)
            {

                var temp = _mapper.Map<CourseReadonlyDTO>(item);


                courseReadonlyDTOs.Add(temp);

            }


            return courseReadonlyDTOs;
        }
        else
        {
            return null;
        }



    }

}
