using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Api.Domain.Entities;

namespace Orders.Api.Infrastructure.Configuration
{
    internal class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.SenderCity)
                .HasMaxLength(100).IsRequired();

            builder.Property(x => x.SenderAddress)
                .HasMaxLength(500).IsRequired();

            builder.Property(x => x.ReceiverCity)
                .HasMaxLength(100).IsRequired();

            builder.Property(x => x.ReceiverAddress)
                .HasMaxLength(500).IsRequired();

            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.PickupDate).IsRequired();
        }
    }
}
