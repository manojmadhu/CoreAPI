namespace CoreAPI.Model
{
    public class UserCredentialsDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public class Token
    {
        public string UserToken { get; set; }
    }
}
