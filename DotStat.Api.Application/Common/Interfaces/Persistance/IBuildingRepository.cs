using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IBuildingRepository : IRepository<Building>
{
  Building? GetById(BuildingId id);
  Task<Building?> GetByIdAsync(BuildingId id);
  ICollection<Building> GetComplexBuildings(ComplexId complexId);
  Task<ICollection<Building>> GetComplexBuildingsAsync(ComplexId complexId);
  bool Exist(BuildingId id);
  Task<bool> ExistAsync(BuildingId id);
}