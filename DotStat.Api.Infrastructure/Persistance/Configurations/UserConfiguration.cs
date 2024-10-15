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
    ConfigureUserRolesTable(builder);
    ConfigureUserClaimsTable(builder);
  }

  private void ConfigureUserClaimsTable(EntityTypeBuilder<User> builder)
  {
    builder.OwnsMany(u => u.Claims, cb =>
    {
      cb.ToTable("user_claims");

      cb.WithOwner().HasForeignKey("UserId");

      cb.HasKey("Id", "UserId");

      cb.Property(r => r.Id)
        .HasColumnName("UserClaimId")
        .ValueGeneratedOnAdd()
        .HasConversion(
          id => id.Value,
          value => UserClaimId.Create(value)
        );

      cb.Property(r => r.Type)
        .IsRequired();

      cb.Property(r => r.Value)
        .IsRequired();
    });

    builder.Metadata.FindNavigation(nameof(User.Claims))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureUserRolesTable(EntityTypeBuilder<User> builder)
  {
    builder.OwnsMany(u => u.Roles, rb =>
    {
      rb.ToTable("user_roles");

      rb.WithOwner().HasForeignKey("UserId");

      rb.HasKey("Id", "UserId");

      rb.Property(r => r.Id)
        .HasColumnName("UserRoleId")
        .ValueGeneratedOnAdd()
        .HasConversion(
          id => id.Value,
          value => UserRoleId.Create(value)
        );

      rb.Property(r => r.Name)
        .IsRequired();

      rb.Property(r => r.NormalizedName)
        .IsRequired();
    });

    builder.Metadata.FindNavigation(nameof(User.Roles))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private void ConfigureRefreshTokensTable(EntityTypeBuilder<User> builder)
  {
    builder.OwnsMany(u => u.RefreshTokens, sb =>
    {
      sb.ToTable("refresh_tokens");

      sb.WithOwner().HasForeignKey("UserId");

      sb.HasKey("Id", "UserId");

      sb.Property(rt => rt.Id)
        .HasColumnName("RefreshTokenId")
        .ValueGeneratedOnAdd()
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
    builder.ToTable("users");

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