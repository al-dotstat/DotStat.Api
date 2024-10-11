using DotStat.Api.Domain.DistrictAggregate;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
  public void Configure(EntityTypeBuilder<District> builder)
  {
    ConfigureDistrictsTable(builder);
  }

  private void ConfigureDistrictsTable(EntityTypeBuilder<District> builder)
  {
    builder.ToTable("Districts");

    builder.HasKey(d => d.Id);

    builder.Property(d => d.Id)
      .HasConversion(id => id.Value, value => DistrictId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(d => d.Name)
      .IsRequired();

    builder.Property(d => d.CreatedDateTime)
      .IsRequired();

    builder.Property(d => d.UpdatedDateTime)
      .IsRequired();
  }
}
