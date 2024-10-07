using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ComplexConfiguration : IEntityTypeConfiguration<Complex>
{
  public void Configure(EntityTypeBuilder<Complex> builder)
  {
    ConfigureComplexesTable(builder);
    ConfigureComplexDevelopersTable(builder);
    ConfigureDistrictsTable(builder);
    ConfigureMetrosTable(builder);
  }

  private void ConfigureComplexDevelopersTable(EntityTypeBuilder<Complex> builder)
  {
    builder.OwnsMany(c => c.Developers, d =>
    {
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

  private void ConfigureMetrosTable(EntityTypeBuilder<Complex> builder)
  {
    builder.OwnsOne(c => c.Metro, cb =>
    {
      cb.ToTable("Metros");

      cb.WithOwner().HasForeignKey("MetroId");

      cb.HasKey("Id", "MetroId");

      cb.Property(m => m.Id)
        .HasColumnName("MetroId")
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => MetroId.Create(value)
        );

      cb.Property(m => m.Name)
        .IsRequired();

      cb.Property(m => m.CreatedDateTime)
        .IsRequired();

      cb.Property(m => m.UpdatedDateTime)
        .IsRequired();
    });

    builder.Metadata.FindNavigation(nameof(Complex.District))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureDistrictsTable(EntityTypeBuilder<Complex> builder)
  {
    builder.OwnsOne(c => c.District, cb =>
    {
      cb.ToTable("Districts");

      cb.WithOwner().HasForeignKey("ComplexId");

      cb.HasKey("Id", "ComplexId");

      cb.Property(d => d.Id)
        .HasColumnName("DistrictId")
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => DistrictId.Create(value)
        );

      cb.Property(d => d.Name)
        .IsRequired();

      cb.Property(d => d.CreatedDateTime)
        .IsRequired();

      cb.Property(d => d.UpdatedDateTime)
        .IsRequired();
    });

    builder.Metadata.FindNavigation(nameof(Complex.District))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureComplexesTable(EntityTypeBuilder<Complex> builder)
  {
    builder.ToTable("Complexes");

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
  }
}
