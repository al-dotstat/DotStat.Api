using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.DistrictAggregate;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ComplexConfiguration : IEntityTypeConfiguration<Complex>
{
  public void Configure(EntityTypeBuilder<Complex> builder)
  {
    ConfigureComplexesTable(builder);
    ConfigureComplexDevelopersTable(builder);
  }

  private void ConfigureComplexDevelopersTable(EntityTypeBuilder<Complex> builder)
  {
    builder.OwnsMany(c => c.Developers, d =>
    {
      d.ToTable("complex_developers");

      d.WithOwner().HasForeignKey("ComplexId");

      d.Property("Id");
      d.HasKey("Id", "ComplexId");

      d.Property(d => d.DeveloperId)
        .HasConversion(id => id.Value, value => DeveloperId.Create(value))
        .ValueGeneratedNever();

      d.HasOne<Developer>()
        .WithMany()
        .HasForeignKey(d => d.DeveloperId)
        .OnDelete(DeleteBehavior.Cascade);
    });
  }

  private void ConfigureComplexesTable(EntityTypeBuilder<Complex> builder)
  {
    builder.ToTable("complexes");

    builder.HasKey(c => c.Id);

    builder.Property(c => c.Id)
      .HasConversion(id => id.Value, value => ComplexId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(c => c.Name)
      .IsRequired();

    builder.Property(c => c.NameRu)
    .IsRequired();

    builder.Property(c => c.CreatedDateTime)
      .IsRequired();

    builder.Property(c => c.UpdatedDateTime)
      .IsRequired();

    builder.Property(c => c.DistrictId)
        .HasConversion(id => id.Value, value => DistrictId.Create(value))
        .ValueGeneratedNever();

    builder.HasOne<District>()
      .WithMany()
      .HasForeignKey(c => c.DistrictId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}
