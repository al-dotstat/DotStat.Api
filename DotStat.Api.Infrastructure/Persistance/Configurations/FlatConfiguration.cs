using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.FlatAggregate;
using DotStat.Api.Domain.FlatAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class FlatConfiguration : IEntityTypeConfiguration<Flat>
{
  public void Configure(EntityTypeBuilder<Flat> builder)
  {
    ConfigureFlatsTable(builder);
    ConfigureParsingInfoTable(builder);
    ConfigureDeclarationTable(builder);
  }

  private void ConfigureDeclarationTable(EntityTypeBuilder<Flat> builder)
  {
    builder.OwnsOne(f => f.Declaration, db =>
    {
      db.ToTable("flat_declaration");

      db.WithOwner().HasForeignKey("FlatId");

      db.HasKey("Id", "FlatId");

      db.Property(d => d.Id)
        .HasColumnName("DeclarationId")
        .ValueGeneratedOnAdd()
        .HasConversion(
          id => id.Value,
          value => FlatDeclarationId.Create(value)
        );

      db.Property(d => d.Number)
        .IsRequired();

      db.Property(d => d.Roominess)
        .IsRequired();

      db.Property(d => d.Floor)
        .IsRequired();

      db.Property(d => d.Area)
        .IsRequired();

      db.Property(d => d.LivingArea)
        .IsRequired();

      db.Property(d => d.CeilingHeight)
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

    builder.Metadata.FindNavigation(nameof(Flat.Declaration))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureParsingInfoTable(EntityTypeBuilder<Flat> builder)
  {
    builder.OwnsMany(f => f.ParsingInfos, fb =>
    {
      fb.ToTable("flat_parsing_infos");

      fb.WithOwner().HasForeignKey("FlatId");

      fb.HasKey("Id", "FlatId");

      fb.Property(pi => pi.Id)
        .HasColumnName("FlatParsingInfoId")
        .ValueGeneratedOnAdd()
        .HasConversion(
          id => id.Value,
          value => FlatParsingInfoId.Create(value)
        );

      fb.Property(pi => pi.Date)
        .IsRequired();

      fb.Property(pi => pi.Price)
        .IsRequired();

      fb.Property(pi => pi.CreatedDateTime)
        .IsRequired();

      fb.Property(pi => pi.UpdatedDateTime)
        .IsRequired();

      fb.Property(pi => pi.ParseId)
        .HasConversion(id => id.Value, value => ParseId.Create(value));

      fb.HasOne<Parse>()
        .WithMany()
        .HasForeignKey(pi => pi.ParseId);
    });
  }

  private void ConfigureFlatsTable(EntityTypeBuilder<Flat> builder)
  {
    builder.ToTable("flats");

    builder.HasKey(f => f.Id);

    builder.Property(f => f.Id)
      .HasConversion(id => id.Value, value => FlatId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(c => c.Title)
      .IsRequired();

    builder.Property(f => f.CreatedDateTime)
      .IsRequired();

    builder.Property(r => r.UpdatedDateTime)
      .IsRequired();

    builder.Property(f => f.BuildingId)
      .HasConversion(id => id.Value, value => BuildingId.Create(value));

    builder.Property(f => f.DeveloperId)
      .HasConversion(id => id.Value, value => DeveloperId.Create(value));

    builder.HasOne<Building>()
      .WithMany()
      .HasForeignKey(f => f.BuildingId);

    builder.HasOne<Developer>()
    .WithMany()
    .HasForeignKey(f => f.DeveloperId);
  }
}
