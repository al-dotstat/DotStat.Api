using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
  public void Configure(EntityTypeBuilder<Building> builder)
  {
    ConfigureBuildingsTable(builder);
  }

  private void ConfigureBuildingsTable(EntityTypeBuilder<Building> builder)
  {
    builder.ToTable("Buildings");

    builder.HasKey(b => b.Id);

    builder.Property(b => b.Id)
      .HasConversion(id => id.Value, value => BuildingId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(b => b.Name)
      .IsRequired();

    builder.Property(b => b.CreatedDateTime)
      .IsRequired();

    builder.Property(b => b.UpdatedDateTime)
      .IsRequired();

    builder.Property(b => b.ComplexId)
      .HasConversion(id => id.Value, value => ComplexId.Create(value))
      .ValueGeneratedNever();

    builder.HasOne<Complex>()
      .WithMany()
      .HasForeignKey(b => b.ComplexId);
  }
}
