using EntityExample2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EntityExample2.Models;

namespace EntityExample2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<StudentModel> StudentsTable { get; set; }
        public DbSet<EmployeeModel> EmployeeTable { get; set; }
    }
}