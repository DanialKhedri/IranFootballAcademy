using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Course;

public class BuyedCourse
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int CourseId { get; set; }

    [Required]
    public DateTime DateBuyed { get; set; } = DateTime.Now;


    //Navigation Properties

    public User User { get; set; }

    public Course Course { get; set; }
}
