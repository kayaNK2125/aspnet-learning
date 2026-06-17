using System.ComponentModel.DataAnnotations;

namespace PracticeWebApp.Models
{
    public class Studentcs
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CID { get; set; }
    }
}
