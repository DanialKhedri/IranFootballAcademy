using Application.DTOs.Course.Video;
using Domain.Entities.Course;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Course;

public class CourseReadonlyDTO
{

    public int Id { get; set; }


    public string Author { get; set; }


    public string Title { get; set; }

    public string Description { get; set; }


    public string Time { get; set; }

    public string For { get; set; }


    public string WhyUs { get; set; }

    public string ImageUrl { get; set; }

    public int Price { get; set; }


    public List<ReadOnlyVideoDTO> Videos { get; set; } = new List<ReadOnlyVideoDTO> { };




}
