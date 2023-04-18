using EntityExample.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EntityExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StudentModel> StudentsEntity { get; set; }
    }
}