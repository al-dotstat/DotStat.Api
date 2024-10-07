using DotStat.Api.Domain.UserAggregate;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotStat.Api.Infrastructure.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    ConfigureUserTable(builder);
    ConfigureRefreshTokensTable(builder);
  }

  private void ConfigureRefreshTokensTable(EntityTypeBuilder<User> builder)
  {
    builder.OwnsMany(u => u.RefreshTokens, sb =>
    {
      sb.ToTable("RefreshTokens");

      sb.WithOwner().HasForeignKey("UserId");

      sb.HasKey("Id", "UserId");

      sb.Property(rt => rt.Id)
        .HasColumnName("RefreshTokenId")
        .ValueGeneratedNever()
        .HasConversion(
          id => id.Value,
          value => RefreshTokenId.Create(value)
        );

      sb.Property(rt => rt.ExpiredDateTime).IsRequired();
    });

    builder.Metadata.FindNavigation(nameof(User.RefreshTokens))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureUserTable(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("Users");

    builder.HasKey(u => u.Id);

    builder.Property(u => u.Id)
      .HasConversion(id => id.Value, value => UserId.Create(value))
      .ValueGeneratedOnAdd();

    builder.HasIndex(u => u.Email).IsUnique();

    builder.Property(u => u.FirstName)
      .IsRequired()
      .HasMaxLength(250);

    builder.Property(u => u.LastName)
      .HasMaxLength(250);

    builder.Property(u => u.MiddleName)
      .HasMaxLength(250);

    builder.Property(u => u.Email)
      .IsRequired();

    builder.Property(u => u.PasswordHash)
      .IsRequired();

    builder.Property(b => b.CreatedDateTime)
      .IsRequired();

    builder.Property(b => b.UpdatedDateTime)
      .IsRequired();
  }
}