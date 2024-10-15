using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.ParkingAggregate;
using DotStat.Api.Domain.ParkingAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class ParkingConfiguration : IEntityTypeConfiguration<Parking>
{
  public void Configure(EntityTypeBuilder<Parking> builder)
  {
    ConfigureParkingsTable(builder);
    ConfigureParsingInfoTable(builder);
    ConfigureDeclarationTable(builder);
  }

  private void ConfigureDeclarationTable(EntityTypeBuilder<Parking> builder)
  {
    builder.OwnsOne(p => p.Declaration, db =>
    {
      db.ToTable("parking_declaration");

      db.WithOwner().HasForeignKey("ParkingId");

      db.HasKey("Id", "ParkingId");

      db.Property(d => d.Id)
        .HasColumnName("DeclarationId")
        .ValueGeneratedOnAdd()
        .HasConversion(
          id => id.Value,
          value => ParkingDeclarationId.Create(value)
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

    builder.Metadata.FindNavigation(nameof(Parking.Declaration))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureParsingInfoTable(EntityTypeBuilder<Parking> builder)
  {
    builder.OwnsMany(f => f.ParsingInfos, pb =>
    {
      pb.ToTable("parking_parsing_infos");

      pb.WithOwner().HasForeignKey("ParkingId");

      pb.HasKey("Id", "ParkingId");

      pb.Property(pi => pi.Id)
        .HasColumnName("ParkingParsingInfoId")
        .ValueGeneratedOnAdd()
        .HasConversion(
          id => id.Value,
          value => ParkingParsingInfoId.Create(value)
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
        .HasConversion(id => id.Value, value => ParseId.Create(value));

      pb.HasOne<Parse>()
        .WithMany()
        .HasForeignKey(pi => pi.ParseId);
    });
  }

  private void ConfigureParkingsTable(EntityTypeBuilder<Parking> builder)
  {
    builder.ToTable("parkings");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id)
      .HasConversion(id => id.Value, value => ParkingId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(p => p.Title)
      .IsRequired();

    builder.Property(p => p.CreatedDateTime)
      .IsRequired();

    builder.Property(p => p.UpdatedDateTime)
      .IsRequired();

    builder.Property(p => p.BuildingId)
      .HasConversion(id => id.Value, value => BuildingId.Create(value));

    builder.Property(p => p.DeveloperId)
      .HasConversion(id => id.Value, value => DeveloperId.Create(value));

    builder.HasOne<Building>()
      .WithMany()
      .HasForeignKey(p => p.BuildingId);

    builder.HasOne<Developer>()
      .WithMany()
      .HasForeignKey(p => p.DeveloperId);
  }
}
