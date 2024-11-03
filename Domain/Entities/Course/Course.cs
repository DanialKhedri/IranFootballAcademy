#region usings
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Domain.Entities.Course;

public class Course
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
    public string ImageUrl { get; set; }


    [Required]
    public int Price { get; set; }


    [Required]
    public string For { get; set; }


    [Required]
    public string WhyUs { get; set; }
         

    [Required]
    public bool IsDelete { get; set; } = false;

    //Navigation Properties
    public ICollection<Video> Videos { get; set; }

}
