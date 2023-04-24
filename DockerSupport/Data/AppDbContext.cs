using DockerSupport.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerSupport.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<StudentModel> StudentTableForDockerSupport { get; set; }
    }
}
