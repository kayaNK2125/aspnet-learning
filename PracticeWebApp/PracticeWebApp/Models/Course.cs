using System.ComponentModel.DataAnnotations;

namespace PracticeWebApp.Models
{
    public class Course
    {

        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
