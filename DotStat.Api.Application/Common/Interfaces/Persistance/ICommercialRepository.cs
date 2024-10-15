using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.CommercialAggregate;
using DotStat.Api.Domain.CommercialAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface ICommercialRepository : IRepository<Commercial>
{
  Commercial? GetById(CommercialId id);
  Task<Commercial?> GetByIdAsync(CommercialId id);
  ICollection<Commercial> GetBuildingCommercials(BuildingId buildingId);
  Task<ICollection<Commercial>> GetBuildingCommercialsAsync(BuildingId buildingId);
  bool Exist(CommercialId id);
  Task<bool> ExistAsync(CommercialId id);
}