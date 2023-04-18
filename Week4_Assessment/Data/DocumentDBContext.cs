using Microsoft.EntityFrameworkCore;
using Text_Editor.Models;

namespace Text_Editor.Data
{
    public class DocumentDBContext : DbContext
    {
        public DocumentDBContext(DbContextOptions<DocumentDBContext> options) : base(options)
        {
        }

        public DbSet<DocumentDBContext> Documents { get; set; }
    }
}
