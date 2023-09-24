using CoreAPI.Repository;
using CoreAPI.Services;

namespace CoreAPI.Model.DataHandler
{
    public class UserCredentialHandler : IUserLoginHandlerRepository<UserCredentialsDto>
    {
        readonly EmployeeContext _employeeContext;

        public UserCredentialHandler(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public int Add(UserCredentialsDto entity)
        {
            throw new NotImplementedException();
        }

        public Token GetToken(UserCredentialsDto entity, IConfiguration configuration)
        {
            string token = "";
            string hashPassword =
            AuthService.GetHashed(entity.Password);

            var userDetail =
            _employeeContext.UserLogins.FirstOrDefault(a => a.Username == entity.UserName && a.Password == hashPassword);
            if (userDetail != null)
            {
                token = AuthService.CreateToken(userDetail, configuration);
            }

            if(string.IsNullOrEmpty(token))
            {
                return null;
            }

            Token tokenDto = new Token
            {
                UserToken = token
            };

            return tokenDto;
        }

        public UserCredentialsDto GetUserDetail(UserCredentialsDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
