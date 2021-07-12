using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.DatabaseModels;

namespace Repository.DatabaseConfigurations
{
    class RedBetCustomerConfiguration : IEntityTypeConfiguration<RedBetCustomer>
    {
        public void Configure(EntityTypeBuilder<RedBetCustomer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FavoriteFootballTeam)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(p => p.BaseCustomerInfo).WithOne().HasForeignKey<RedBetCustomer>(x => x.BaseCustomerInfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
