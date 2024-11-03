using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Course.Video;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Application.DTOs.Course;

public class EditCourseDTO
{
    [Required]
    public int Id { get; set; }

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

    [Required]
    public string For { get; set; }

    [Required]
    public string WhyUs { get; set; }

    public string ImageUrl { get; set; }

    public List<AddVideoDTO> videos { get; set; }
}
