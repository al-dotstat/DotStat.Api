using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.FlatAggregate;
using DotStat.Api.Domain.FlatAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class FlatRepository(DotStatApiDbContext dbContext) : Repository<Flat>(dbContext), IFlatRepository
{
  public bool Exist(FlatId id)
  {
    return _dbContext.Flats.Any(f => f.Id == id);
  }

  public Task<bool> ExistAsync(FlatId id)
  {
    return _dbContext.Flats.AnyAsync(f => f.Id == id);
  }

  public Flat? GetById(FlatId id)
  {
    return _dbContext.Flats.Find(id);
  }

  public async Task<Flat?> GetByIdAsync(FlatId id)
  {
    return await _dbContext.Flats.FindAsync(id);
  }

  public ICollection<Flat> GetBuildingFlats(BuildingId buildingId)
  {
    return [.. _dbContext.Flats.Where(f => f.BuildingId == buildingId)];
  }

  public async Task<ICollection<Flat>> GetBuildingFlatsAsync(BuildingId buildingId)
  {
    return await _dbContext.Flats.Where(f => f.BuildingId == buildingId).ToListAsync();
  }

  public ICollection<Flat> GetComplexFlats(ComplexId complexId)
  {
    var complexBuildingIds = _dbContext.Buildings
      .Where(b => b.ComplexId == complexId)
      .Select(b => b.Id);

    return [..
      _dbContext.Flats
        .Where(f => complexBuildingIds.Any(bid => bid == f.BuildingId))
    ];
  }

  public async Task<ICollection<Flat>> GetComplexFlatsAsync(ComplexId complexId)
  {
    var complexBuildingIds = _dbContext.Buildings
      .Where(b => b.ComplexId == complexId)
      .Select(b => b.Id);

    return await _dbContext.Flats
      .Where(f => complexBuildingIds.Any(bid => bid == f.BuildingId))
      .ToListAsync();
  }
}
