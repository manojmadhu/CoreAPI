using CoreAPI.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CoreAPI.Services
{
    public class AuthService
    {
        public static string GetHashed(string rawPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] salt = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: rawPassword!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
                return hashed.ToString();
            }
        }

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
            hashPassword = GetHashed(rawPassword);
        }

        public static string CreateToken(UserLogin user, IConfiguration configuration)
        {
            try
            {
                List<Claim> claims = new List<Claim>{
                    new Claim(ClaimTypes.Name,user.Username),
                    new Claim(ClaimTypes.Role, user.UserRole)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    configuration.GetSection("AppSettings:Key").Value
                    ));

                var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials
                    );

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return jwtToken;

            }catch(Exception e) { return null; }
        }
    }
}
