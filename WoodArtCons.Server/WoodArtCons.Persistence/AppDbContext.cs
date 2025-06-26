using Microsoft.EntityFrameworkCore;
using WoodArtCons.Server.WoodArtCons.Persistence.Entities;

namespace WoodArtCons.Server.WoodArtCons.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CategoryProductModel> Products { get; set; }

    }
}
