using Concurrency_Token.Models;
using Microsoft.EntityFrameworkCore;

namespace Concurrency_Token.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ProductsModel> productsModel { get; set; }
    }
}
