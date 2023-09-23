using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Model
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<UserLogin> UserLogins { get; set; }    
        public DbSet<Employee> Employees { get; set;}

    }
}
