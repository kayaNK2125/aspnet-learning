namespace FirstMVCWebApp.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!; //suppressing compiler warning null nai hogi letter aajayega username sure
        public string Email {get; set;} = null!;
        public string Password {get; set;} = null!;
    }    
}
