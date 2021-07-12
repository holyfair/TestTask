using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.DatabaseModels;

namespace Repository.DatabaseConfigurations
{
    class MrGreenCustomerConfiguration : IEntityTypeConfiguration<MrGreenCustomer>
    {
        public void Configure(EntityTypeBuilder<MrGreenCustomer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PersonalNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(p => p.BaseCustomerInfo).WithOne().HasForeignKey<MrGreenCustomer>(x => x.BaseCustomerInfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
