using Microsoft.EntityFrameworkCore;
using Repository.DatabaseConfigurations;
using Repository.DatabaseModels;
using System.Linq;
using System.Reflection;

namespace Repository.Context
{
    public class AppDbContext : DbContext
    {
        internal virtual DbSet<Brand> Brands { get; set; }
        internal virtual DbSet<MrGreenBrand> MrGreenBrands { get; set; }
        internal virtual DbSet<RedBetBrand> RedBetBrands { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new MrGreenBrandConfiguration());
            modelBuilder.ApplyConfiguration(new RedBetConfiguration());
        }
    }
}
