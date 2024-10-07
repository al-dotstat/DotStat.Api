using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.CommercialAggregate;
using DotStat.Api.Domain.CommercialAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class CommercialConfiguration : IEntityTypeConfiguration<Commercial>
{
  public void Configure(EntityTypeBuilder<Commercial> builder)
  {
    ConfigureCommercialsTable(builder);
    ConfigureParsingInfoTable(builder);
    ConfigureDeclarationTable(builder);
  }

  private void ConfigureDeclarationTable(EntityTypeBuilder<Commercial> builder)
  {
    builder.OwnsOne(p => p.Declaration, db =>
    {
      db.ToTable("CommercialDeclarations");

      db.WithOwner().HasForeignKey("CommercialId");

      db.HasKey("Id", "CommercialId");

      db.Property(d => d.Id)
        .HasColumnName("DeclarationId")
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => CommercialDeclarationId.Create(value)
        );

      db.Property(d => d.Number)
        .IsRequired();

      db.Property(d => d.Floor)
        .IsRequired();

      db.Property(d => d.Area)
        .IsRequired();

      db.Property(d => d.Entrance)
        .IsRequired();

      db.Property(d => d.Unique)
        .IsRequired();

      db.Property(d => d.CreatedDateTime)
        .IsRequired();

      db.Property(d => d.UpdatedDateTime)
        .IsRequired();
    });

    builder.Metadata.FindNavigation(nameof(Commercial.Declaration))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureParsingInfoTable(EntityTypeBuilder<Commercial> builder)
  {
    builder.OwnsMany(f => f.ParsingInfos, pb =>
    {
      pb.ToTable("CommercialParsingInfos");

      pb.WithOwner().HasForeignKey("CommercialId");

      pb.HasKey("Id", "CommercialId");

      pb.Property(pi => pi.Id)
        .HasColumnName("CommercialParsingInfoId")
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => CommercialParsingInfoId.Create(value)
        );

      pb.Property(pi => pi.Date)
        .IsRequired();

      pb.Property(pi => pi.Price)
        .IsRequired();

      pb.Property(pi => pi.CreatedDateTime)
        .IsRequired();

      pb.Property(pi => pi.UpdatedDateTime)
        .IsRequired();

      pb.Property(pi => pi.ParseId)
      .HasConversion(id => id.Value, value => ParseId.Create(value))
      .ValueGeneratedNever();

      pb.HasOne<Parse>()
        .WithMany()
        .HasForeignKey(pi => pi.ParseId);
    });
  }

  private void ConfigureCommercialsTable(EntityTypeBuilder<Commercial> builder)
  {
    builder.ToTable("Commercials");

    builder.HasKey(c => c.Id);

    builder.Property(c => c.Id)
      .HasConversion(id => id.Value, value => CommercialId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(c => c.Title)
      .IsRequired();

    builder.Property(c => c.CreatedDateTime)
      .IsRequired();

    builder.Property(c => c.UpdatedDateTime)
      .IsRequired();

    builder.Property(c => c.BuildingId)
      .HasConversion(id => id.Value, value => BuildingId.Create(value))
      .ValueGeneratedNever();

    builder.Property(c => c.DeveloperId)
      .HasConversion(id => id.Value, value => DeveloperId.Create(value))
      .ValueGeneratedNever();

    builder.HasOne<Building>()
      .WithMany()
      .HasForeignKey(c => c.BuildingId);

    builder.HasOne<Developer>()
    .WithMany()
    .HasForeignKey(c => c.DeveloperId);
  }
}
