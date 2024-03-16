using EmployeeData.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Employee> Employeess{ get; set; }

    }
}
