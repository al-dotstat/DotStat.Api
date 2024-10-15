using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
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
}
