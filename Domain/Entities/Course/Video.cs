using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Course
{
    public class Video
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }


        [Required]
        public string Title { get; set; }


        [Required]
        public string VideoUrl { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;


        //Navigation Properties
        public Course Course { get; set; }
    }

}
