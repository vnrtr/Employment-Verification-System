using Employment_Verification_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employment_Verification_API.ApplicationDbContext
{
    public class EmployeeContext(DbContextOptions<EmployeeContext> options) : DbContext(options)
    {
        public required DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for the in-memory database
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, CompanyName = "cisive", VerificationCode = "12345" },
                new Employee { EmployeeID = 2, CompanyName = "HCLTech", VerificationCode = "abcde" },
                new Employee { EmployeeID = 3, CompanyName = "DishTV", VerificationCode = "ASDFG" },
                new Employee { EmployeeID = 4, CompanyName = "Youth4work", VerificationCode = "08642" },
                new Employee { EmployeeID = 5, CompanyName = "ALCHEMY", VerificationCode = "AD468" }
            );
        }
    }
}
