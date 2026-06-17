using System.ComponentModel.DataAnnotations;

namespace PracticeWebApp.Models
{
    public class LINQ_Employe_Model
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }
}
