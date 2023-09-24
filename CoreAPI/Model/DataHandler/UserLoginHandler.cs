using CoreAPI.Repository;
using System.Transactions;

namespace CoreAPI.Model.DataHandler
{
    public class UserLoginHandler : IDataHandlerRepository<UserLogin>
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

        public int Delete(UserLogin entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserLogin>> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserLogin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(UserLogin targetEntity, UserLogin entity)
        {
            throw new NotImplementedException();
        }
    }
}
