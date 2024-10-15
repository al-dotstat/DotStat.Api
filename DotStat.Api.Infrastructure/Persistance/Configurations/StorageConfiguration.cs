using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;
using DotStat.Api.Domain.StorageAggregate;
using DotStat.Api.Domain.StorageAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class StorageConfiguration : IEntityTypeConfiguration<Storage>
{
  public void Configure(EntityTypeBuilder<Storage> builder)
  {
    ConfigureStoragesTable(builder);
    ConfigureParsingInfoTable(builder);
    ConfigureDeclarationTable(builder);
  }

  private void ConfigureDeclarationTable(EntityTypeBuilder<Storage> builder)
  {
    builder.OwnsOne(p => p.Declaration, db =>
    {
      db.ToTable("storage_declaration");

      db.WithOwner().HasForeignKey("StorageId");

      db.HasKey("Id", "StorageId");

      db.Property(d => d.Id)
        .HasColumnName("DeclarationId")
        .ValueGeneratedOnAdd()
        .HasConversion(
          id => id.Value,
          value => StorageDeclarationId.Create(value)
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

    builder.Metadata.FindNavigation(nameof(Storage.Declaration))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureParsingInfoTable(EntityTypeBuilder<Storage> builder)
  {
    builder.OwnsMany(f => f.ParsingInfos, pb =>
    {
      pb.ToTable("storage_parsing_infos");

      pb.WithOwner().HasForeignKey("StorageId");

      pb.HasKey("Id", "StorageId");

      pb.Property(pi => pi.Id)
        .HasColumnName("StorageParsingInfoId")
        .ValueGeneratedOnAdd()
        .HasConversion(
          id => id.Value,
          value => StorageParsingInfoId.Create(value)
        );

      pb.Property(pi => pi.Date)
        .IsRequired();

      pb.Property(pi => pi.Price)
        .IsRequired();

      pb.Property(pi => pi.CreatedDateTime)
        .IsRequired();

      pb.Property(pi => pi.UpdatedDateTime)
        .IsRequired();

      pb.Property(f => f.ParseId)
        .HasConversion(id => id.Value, value => ParseId.Create(value));

      pb.HasOne<Parse>()
        .WithMany()
        .HasForeignKey(pi => pi.ParseId);
    });
  }

  private void ConfigureStoragesTable(EntityTypeBuilder<Storage> builder)
  {
    builder.ToTable("storages");

    builder.HasKey(s => s.Id);

    builder.Property(s => s.Id)
      .HasConversion(id => id.Value, value => StorageId.Create(value))
      .ValueGeneratedOnAdd();

    builder.Property(s => s.Title)
      .IsRequired();

    builder.Property(s => s.CreatedDateTime)
      .IsRequired();

    builder.Property(s => s.UpdatedDateTime)
      .IsRequired();

    builder.Property(s => s.BuildingId)
      .HasConversion(id => id.Value, value => BuildingId.Create(value));

    builder.Property(s => s.DeveloperId)
      .HasConversion(id => id.Value, value => DeveloperId.Create(value));

    builder.HasOne<Building>()
      .WithMany()
      .HasForeignKey(s => s.BuildingId);

    builder.HasOne<Developer>()
    .WithMany()
    .HasForeignKey(s => s.DeveloperId);
  }
}
