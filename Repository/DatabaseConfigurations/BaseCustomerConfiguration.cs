using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.DatabaseModels;

namespace Repository.DatabaseConfigurations
{
    class BaseCustomerConfiguration : IEntityTypeConfiguration<BaseCustomer>
    {
        public void Configure(EntityTypeBuilder<BaseCustomer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Street)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.ZipCode);

            builder.Property(p => p.House);
        }
    }
}
