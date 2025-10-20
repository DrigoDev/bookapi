using BookAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
