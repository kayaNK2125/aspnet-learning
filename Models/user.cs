using System.ComponentModel.DataAnnotations;

namespace FirstMVCWebApp.Models
{
    public class User
    {
        //creating colums:
        [Key] //Id key hai jo uniq hoga hr condition mein
        public int Id { get; set; }
        public string Username { get; set; } = null!; //suppressing compiler warning null nai hogi letter aajayega username sure
        public string Email {get; set;} = null!;
        public string password {get; set;} = null!;
    }
}