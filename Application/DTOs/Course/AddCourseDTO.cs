using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Course.Video;

namespace Application.DTOs.Course;

public class AddCourseDTO
{

    [Required]
    public string Author { get; set; }

    [Required]
    public string Title { get; set; }


    [Required]
    public string Description { get; set; }



    [Required]
    public string Time { get; set; }


    [Required]
    public int Price { get; set; }


    public string ImageUrl { get; set; }



    [Required]
    public string For { get; set; }

    [Required]
    public string WhyUs { get; set; }






    public List<AddVideoDTO>? videos { get; set; }

}
