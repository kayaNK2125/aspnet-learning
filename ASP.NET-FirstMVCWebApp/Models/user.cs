using System.ComponentModel.DataAnnotations;

namespace FirstMVCWebApp.Models
{
    public class User
    {
        //creating colums:
        [Key] //Id is primary key
        public int Id { get; set; }
        public string Username { get; set; } = null!; // non-nullable
        public string Email {get; set;} = null!;
        public string password {get; set;} = null!;
    }
}