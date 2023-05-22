using API.Database_Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database_Context
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContext) : base(dbContext)
        {
            
        }

        public DbSet<Employee> Employees => Set<Employee>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Server=.;Database=RecomEmpDb;Trusted_Connection=True"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                
                new Employee
                {
                    Id = 1,
                    Name = "Test",
                    JoiningDate=DateTime.Parse("02-02-2020"),
                    Salary=50000,
                    IsManager=true
                }
                
            );
        }
    }
}
