using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class BuildingRepository(DotStatApiDbContext dbContext) : Repository<Building>(dbContext), IBuildingRepository
{
  public bool Exist(BuildingId id)
  {
    return _dbContext.Buildings.Any(b => b.Id == id);
  }

  public async Task<bool> ExistAsync(BuildingId id)
  {
    return await _dbContext.Buildings.AnyAsync(b => b.Id == id);
  }

  public Building? GetById(BuildingId id)
  {
    return _dbContext.Buildings.Find(id);
  }

  public async Task<Building?> GetByIdAsync(BuildingId id)
  {
    return await _dbContext.Buildings.FindAsync(id);
  }

  public ICollection<Building> GetComplexBuildings(ComplexId complexId)
  {
    return [.. _dbContext.Buildings.Where(b => b.ComplexId == complexId)];
  }

  public async Task<ICollection<Building>> GetComplexBuildingsAsync(ComplexId complexId)
  {
    return await _dbContext.Buildings.Where(b => b.ComplexId == complexId).ToListAsync();
  }
}
