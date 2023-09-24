using CoreAPI.Repository;
using CoreAPI.Services;
using Microsoft.Extensions.Configuration;
using System.Transactions;

namespace CoreAPI.Model.DataHandler
{
    public class UserLoginHandler : IUserLoginHandlerRepository<UserLogin>
    {
        readonly EmployeeContext _employeeContext;

        public UserLoginHandler(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public int Add(UserLogin entity)
        {
            using var transaction = _employeeContext.Database.BeginTransaction();
            try
            {
                _employeeContext.Add(entity);
                _employeeContext.SaveChanges();
                transaction.Commit();
                return entity.UserId;
            }
            catch(Exception ex) { 
                transaction.Rollback();
                return 0;
            }
        }

        public Token GetToken(UserLogin entity, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public UserLogin GetUserDetail(UserLogin entity)
        {
            throw new NotImplementedException();
        }
    }
}
