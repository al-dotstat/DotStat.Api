using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.CommercialAggregate;
using DotStat.Api.Domain.CommercialAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class CommercialRepository(DotStatApiDbContext dbContext) : Repository<Commercial>(dbContext), ICommercialRepository
{
  public bool Exist(CommercialId id)
  {
    return _dbContext.Commercials.Any(c => c.Id == id);
  }

  public Task<bool> ExistAsync(CommercialId id)
  {
    return _dbContext.Commercials.AnyAsync(c => c.Id == id);
  }

  public Commercial? GetById(CommercialId id)
  {
    return _dbContext.Commercials.Find(id);
  }

  public async Task<Commercial?> GetByIdAsync(CommercialId id)
  {
    return await _dbContext.Commercials.FindAsync(id);
  }

  public ICollection<Commercial> GetBuildingCommercials(BuildingId buildingId)
  {
    return [.. _dbContext.Commercials.Where(c => c.BuildingId == buildingId)];
  }

  public async Task<ICollection<Commercial>> GetBuildingCommercialsAsync(BuildingId buildingId)
  {
    return await _dbContext.Commercials.Where(c => c.BuildingId == buildingId).ToListAsync();
  }
}