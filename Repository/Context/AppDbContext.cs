using Microsoft.EntityFrameworkCore;
using Repository.DatabaseConfigurations;
using Repository.DatabaseModels;
using System.Linq;
using System.Reflection;

namespace Repository.Context
{
    public class AppDbContext : DbContext
    {
        internal virtual DbSet<BaseCustomer> BaseCustomers { get; set; }
        internal virtual DbSet<MrGreenCustomer> MrGreenCustomers { get; set; }
        internal virtual DbSet<RedBetCustomer> RedBetCustomers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BaseCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new MrGreenCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new RedBetCustomerConfiguration());
        }
    }
}
