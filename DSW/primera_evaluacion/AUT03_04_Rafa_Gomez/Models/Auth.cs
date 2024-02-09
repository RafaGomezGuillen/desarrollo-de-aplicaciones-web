namespace AUT03_04_Rafa_Gomez.Models
{
    public class Auth
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class AuthDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
