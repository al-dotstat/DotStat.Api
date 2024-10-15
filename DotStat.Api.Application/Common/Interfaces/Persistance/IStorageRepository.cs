using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.StorageAggregate;
using DotStat.Api.Domain.StorageAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IStorageRepository : IRepository<Storage>
{
  Storage? GetById(StorageId id);
  Task<Storage?> GetByIdAsync(StorageId id);
  ICollection<Storage> GetBuildingStorages(BuildingId buildingId);
  Task<ICollection<Storage>> GetBuildingStoragesAsync(BuildingId buildingId);
  ICollection<Storage> GetComplexStorages(ComplexId complexId);
  Task<ICollection<Storage>> GetComplexStoragesAsync(ComplexId complexId);
  bool Exist(StorageId id);
  Task<bool> ExistAsync(StorageId id);
}