using CoreAPI.Common;
using CoreAPI.Repository;
using CoreAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Model.DataHandler
{
    public class EmployeeHandler:IDataHandlerRepository<Employee>
    {
        private readonly EmployeeContext _employeeContext;
        private UserLoginHandler _userLoginHandler;

        public EmployeeHandler(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _userLoginHandler = new UserLoginHandler(employeeContext);
        }

        public int Add(Employee entity)
        {
            using var transaction = _employeeContext.Database.BeginTransaction();
            try
            {
                _employeeContext.Employees.Add(entity);
                _employeeContext.SaveChanges();
                transaction.Commit();

                if (entity.EmployeeId > 0)
                {
                    string rawPassword,hashPassword = "";
                    AuthService.GeneratePassword(out rawPassword,out hashPassword);

                    //create user account
                    UserLogin userLogin = new UserLogin
                    {
                        Username = entity.EmailAddress,
                        Password = hashPassword,
                        UserRole = Enum.GetName(typeof(UserRole), UserRole.Employee),
                        EmployeeDetail = entity 
                    };

                    var userId = _userLoginHandler.Add(userLogin);
                    return userId;
                }
                else
                {
                    return 0;
                }             

            }catch(Exception ex) { transaction.Rollback(); return 0; }
        }

        public int Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeContext.Employees.ToListAsync();
        }

        public Employee GetById(int id)
        {
            return _employeeContext.Employees.FirstOrDefault(
                a=>a.EmployeeId == id
                );
        }

        public int Update(Employee targetEntity, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
