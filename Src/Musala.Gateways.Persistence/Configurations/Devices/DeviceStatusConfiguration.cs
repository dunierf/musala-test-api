using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musala.Gateways.Domain.Entities.Devices;

namespace Musala.Gateways.Persistence.Configurations.Devices
{
    public class DeviceStatusConfiguration : IEntityTypeConfiguration<DeviceStatus>
    {
        public void Configure(EntityTypeBuilder<DeviceStatus> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50);

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