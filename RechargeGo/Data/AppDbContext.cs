using Microsoft.EntityFrameworkCore;
using RechargeGo.Models;

namespace RechargeGo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PlansModel> PlansInfo{ get; set; }

        public DbSet<RechargeModel> RechargeInfo { get; set; }

    }
}
