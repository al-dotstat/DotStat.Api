using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class ParseConfiguration : IEntityTypeConfiguration<Parse>
{
  public void Configure(EntityTypeBuilder<Parse> builder)
  {
    ConfigureParseTable(builder);
  }

  private void ConfigureParseTable(EntityTypeBuilder<Parse> builder)
  {
    builder.ToTable("parsings");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id)
      .HasConversion(id => id.Value, value => ParseId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(p => p.Date)
      .IsRequired();

    builder.Property(p => p.AreFlatsParsed)
      .IsRequired();

    builder.Property(p => p.AreParkingsParsed)
      .IsRequired();

    builder.Property(p => p.AreStoragesParsed)
      .IsRequired();

    builder.Property(p => p.AreCommercialsParsed)
      .IsRequired();

    builder.Property(c => c.CreatedDateTime)
      .IsRequired();

    builder.Property(c => c.UpdatedDateTime)
      .IsRequired();

    builder.Property(c => c.ComplexId)
        .HasConversion(id => id.Value, value => ComplexId.Create(value));

    builder.HasOne<Complex>()
      .WithMany()
      .HasForeignKey(c => c.ComplexId);
  }
}