using WebApiWIthEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApiWIthEntity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<StudentModel> StudentsEntity { get; set; }

        public DbSet<sampleModel> SampleTable { get; set; }
    }
}