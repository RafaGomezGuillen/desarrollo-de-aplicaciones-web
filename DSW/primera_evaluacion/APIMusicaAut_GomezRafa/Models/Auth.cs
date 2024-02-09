namespace APIMusicaAut_GomezRafa.Models
{
    public class Auth
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthRole
    {
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
