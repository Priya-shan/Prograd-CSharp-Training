using Job_Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Job_Application.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<JobDetails> Jobs { get; set; }
    }
}
