using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.DatabaseModels;

namespace Repository.DatabaseConfigurations
{
    class RedBetConfiguration : IEntityTypeConfiguration<RedBetBrand>
    {
        public void Configure(EntityTypeBuilder<RedBetBrand> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FavoriteFootballTeam)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(p => p.BrandBaseInfo).WithOne().HasForeignKey<RedBetBrand>(x => x.BrandBaseInfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
