using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
{
  public void Configure(EntityTypeBuilder<Developer> builder)
  {
    ConfigureDevelopersTable(builder);
  }

  private void ConfigureDevelopersTable(EntityTypeBuilder<Developer> builder)
  {
    builder.ToTable("Developers");

    builder.HasKey(d => d.Id);

    builder.Property(d => d.Id)
      .HasConversion(id => id.Value, value => DeveloperId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(d => d.Name)
      .IsRequired();

    builder.Property(d => d.NameRu)
    .IsRequired();

    builder.Property(d => d.CreatedDateTime)
      .IsRequired();

    builder.Property(d => d.UpdatedDateTime)
      .IsRequired();
  }
}
