using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.DatabaseModels;

namespace Repository.DatabaseConfigurations
{
    class MrGreenBrandConfiguration : IEntityTypeConfiguration<MrGreenBrand>
    {
        public void Configure(EntityTypeBuilder<MrGreenBrand> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PersonalNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(p => p.BrandBaseInfo).WithOne().HasForeignKey<MrGreenBrand>(x => x.BrandBaseInfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
