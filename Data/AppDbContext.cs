
using baithi2.Models;
using Microsoft.EntityFrameworkCore;

namespace baithi2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ChuDe> ChuDe => Set<ChuDe>();
        public DbSet<Sach> Sach => Set<Sach>();
    }
}
