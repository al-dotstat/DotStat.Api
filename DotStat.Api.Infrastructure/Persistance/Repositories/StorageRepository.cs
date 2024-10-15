using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
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

  public ICollection<Storage> GetComplexStorages(ComplexId complexId)
  {
    var complexBuildingIds = _dbContext.Buildings
      .Where(b => b.ComplexId == complexId)
      .Select(b => b.Id);

    return [..
      _dbContext.Storages
        .Where(f => complexBuildingIds.Any(bid => bid == f.BuildingId))
    ];
  }

  public async Task<ICollection<Storage>> GetComplexStoragesAsync(ComplexId complexId)
  {
    var complexBuildingIds = _dbContext.Buildings
      .Where(b => b.ComplexId == complexId)
      .Select(b => b.Id);

    return await _dbContext.Storages
      .Where(f => complexBuildingIds.Any(bid => bid == f.BuildingId))
      .ToListAsync();
  }
}
