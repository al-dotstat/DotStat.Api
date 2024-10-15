using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.FlatAggregate;
using DotStat.Api.Domain.FlatAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IFlatRepository : IRepository<Flat>
{
  Flat? GetById(FlatId id);
  Task<Flat?> GetByIdAsync(FlatId id);
  ICollection<Flat> GetBuildingFlats(BuildingId buildingId);
  Task<ICollection<Flat>> GetBuildingFlatsAsync(BuildingId buildingId);
  bool Exist(FlatId id);
  Task<bool> ExistAsync(FlatId id);
}