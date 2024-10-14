using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.OrderAggregate;
using DotStat.Api.Domain.OrderAggregate.ValueObjects;
using DotStat.Api.Domain.UserAggregate;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    ConfigureOrdersTable(builder);
    ConfigureOrderItemsTable(builder);
  }

  private void ConfigureOrderItemsTable(EntityTypeBuilder<Order> builder)
  {
    builder.OwnsMany(o => o.OrderItems, ob =>
    {
      ob.ToTable("order_items");

      ob.WithOwner().HasForeignKey("OrderId");

      ob.Property<int>("Id");
      ob.HasKey("Id", "OrderId");

      ob.Property(i => i.IncludeParkings)
        .IsRequired();

      ob.Property(i => i.IncludeStorages)
        .IsRequired();

      ob.Property(i => i.IncludeFlats)
        .IsRequired();

      ob.Property(i => i.IncludeCommercials)
        .IsRequired();

      ob.Property(i => i.ComplexId)
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => ComplexId.Create(value)
        );

      ob.HasOne<Complex>()
        .WithMany()
        .HasForeignKey(i => i.ComplexId);
    });
  }

  private void ConfigureOrdersTable(EntityTypeBuilder<Order> builder)
  {
    builder.ToTable("orders");

    builder.HasKey(o => o.Id);

    builder.Property(o => o.Id)
      .HasConversion(id => id.Value, value => OrderId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(o => o.FileName)
      .IsRequired();

    builder.Property(o => o.FileExpiredDateTime)
      .IsRequired();

    builder.Property(o => o.CreatedDateTime)
        .IsRequired();

    builder.Property(o => o.UpdatedDateTime)
      .IsRequired();

    builder.Property(o => o.UserId)
      .HasConversion(id => id.Value, value => UserId.Create(value))
      .ValueGeneratedNever();

    builder.HasOne<User>()
      .WithMany()
      .HasForeignKey(o => o.UserId)
      .IsRequired()
      .OnDelete(DeleteBehavior.Cascade);
  }
}
