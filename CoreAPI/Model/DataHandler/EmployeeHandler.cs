using CoreAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Model.DataHandler
{
    public class EmployeeHandler:IDataHandlerRepository<Employee>
    {
        private readonly EmployeeContext employeeContext_context;

        public EmployeeHandler(EmployeeContext employeeContext)
        {
            employeeContext_context = employeeContext;
        }

        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await employeeContext_context.Employees.ToListAsync();

        }

        public Employee GetById(int id)
        {
            return employeeContext_context.Employees.FirstOrDefault(
                a=>a.EmployeeId == id
                );
        }

        public void Update(Employee targetEntity, Employee entity)
        {
            
        }
    }
}
