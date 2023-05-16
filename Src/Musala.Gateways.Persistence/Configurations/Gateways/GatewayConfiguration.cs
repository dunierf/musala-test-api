using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Musala.Gateways.Domain.Entities.Gateways;

namespace Musala.Gateways.Persistence.Configurations.Gateways
{
    public class GatewayConfiguration : IEntityTypeConfiguration<Gateway>
    {
        public void Configure(EntityTypeBuilder<Gateway> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50);

            builder.Property(c => c.SerialNumber)
                .HasMaxLength(50);

            builder.Property(c => c.IpV4Address)
                .HasMaxLength(15);

            builder.HasMany(c => c.Devices)
                .WithOne(c => c.Gateway)
                .HasForeignKey(c => c.GatewayId);

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