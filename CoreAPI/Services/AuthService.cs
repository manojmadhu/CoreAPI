namespace CoreAPI.Services
{
    public class AuthService
    {
        public static void GeneratePassword(out string rawPassword,out string hashPassword)
        {
            String charSet = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int length = 8;
            String randomPassword = "";
            for(int i = 0; i < length;i++)
            {
                int index = random.Next(charSet.Length);
                randomPassword = randomPassword + charSet[index];
            }
            rawPassword = randomPassword;
            hashPassword = randomPassword.GetHashCode().ToString();
        }
    }
}
