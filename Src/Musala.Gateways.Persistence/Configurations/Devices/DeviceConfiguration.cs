using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musala.Gateways.Domain.Entities.Devices;

namespace Musala.Gateways.Persistence.Configurations.Devices
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UId);

            builder.Property(c => c.Vendor)
                .HasMaxLength(50);

            builder.Property(c => c.StatusId);

            builder.HasOne(c => c.Status);

            builder.HasOne(c => c.Gateway);

            builder.Property(c => c.Id)
                .UseIdentityColumn();

            builder.Property(c => c.CreatedDate)
                .IsRequired(true)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.ModifiedDate)
                .IsRequired(true)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}