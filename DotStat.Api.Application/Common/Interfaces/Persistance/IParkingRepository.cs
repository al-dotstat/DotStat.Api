using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.ParkingAggregate;
using DotStat.Api.Domain.ParkingAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IParkingRepository : IRepository<Parking>
{
  Parking? GetById(ParkingId id);
  Task<Parking?> GetByIdAsync(ParkingId id);
  ICollection<Parking> GetBuildingParkings(BuildingId buildingId);
  Task<ICollection<Parking>> GetBuildingParkingsAsync(BuildingId buildingId);
  ICollection<Parking> GetComplexParkings(ComplexId complexId);
  Task<ICollection<Parking>> GetComplexParkingsAsync(ComplexId complexId);
  bool Exist(ParkingId id);
  Task<bool> ExistAsync(ParkingId id);
}