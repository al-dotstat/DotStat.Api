using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.CommercialAggregate;
using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DistrictAggregate;
using DotStat.Api.Domain.FlatAggregate;
using DotStat.Api.Domain.OrderAggregate;
using DotStat.Api.Domain.ParkingAggregate;
using DotStat.Api.Domain.ParseAggregate;
using DotStat.Api.Domain.StorageAggregate;
using DotStat.Api.Domain.UserAggregate;
using DotStat.Api.Infrastructure.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance;

public class DotStatApiDbContext : DbContext
{
  private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

  public DotStatApiDbContext(DbContextOptions<DotStatApiDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
  {
    _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
  }

  public DbSet<User> Users { get; set; } = null!;
  public DbSet<Building> Buildings { get; set; } = null!;
  public DbSet<Developer> Developers { get; set; } = null!;
  public DbSet<Storage> Storages { get; set; } = null!;
  public DbSet<Complex> Complexes { get; set; } = null!;
  public DbSet<Flat> Flats { get; set; } = null!;
  public DbSet<Parking> Parkings { get; set; } = null!;
  public DbSet<Commercial> Commercials { get; set; } = null!;
  public DbSet<Order> Orders { get; set; } = null!;
  public DbSet<District> Districts { get; set; } = null!;
  public DbSet<Parse> Parses { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder
      .Ignore<List<IDomainEvent>>()
      .ApplyConfigurationsFromAssembly(typeof(DotStatApiDbContext).Assembly);

    modelBuilder.HasDefaultSchema("api");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
    base.OnConfiguring(optionsBuilder);
  }
}