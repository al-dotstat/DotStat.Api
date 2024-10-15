using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.StorageAggregate;
using DotStat.Api.Domain.StorageAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class StorageRepository(DotStatApiDbContext dbContext) : Repository<Storage>(dbContext), IStorageRepository
{
  public bool Exist(StorageId id)
  {
    return _dbContext.Storages.Any(s => s.Id == id);
  }

  public Task<bool> ExistAsync(StorageId id)
  {
    return _dbContext.Storages.AnyAsync(s => s.Id == id);
  }

  public Storage? GetById(StorageId id)
  {
    return _dbContext.Storages.Find(id);
  }

  public async Task<Storage?> GetByIdAsync(StorageId id)
  {
    return await _dbContext.Storages.FindAsync(id);
  }

  public ICollection<Storage> GetBuildingStorages(BuildingId buildingId)
  {
    return [.. _dbContext.Storages.Where(s => s.BuildingId == buildingId)];
  }

  public async Task<ICollection<Storage>> GetBuildingStoragesAsync(BuildingId buildingId)
  {
    return await _dbContext.Storages.Where(s => s.BuildingId == buildingId).ToListAsync();
  }
}
