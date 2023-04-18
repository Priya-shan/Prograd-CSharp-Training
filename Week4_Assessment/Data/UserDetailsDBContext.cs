using Microsoft.EntityFrameworkCore;
using Text_Editor.Models;

namespace Text_Editor.Data
{
    public class UserDetailsDBContext : DbContext
    {
        public UserDetailsDBContext(DbContextOptions<UserDetailsDBContext> options) : base(options)
        {
        }

        public DbSet<UserDetailsModel> UserDetails { get; set; }
    }
}
