using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.CommercialAggregate;
using DotStat.Api.Domain.CommercialAggregate.ValueObjects;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface ICommercialRepository : IRepository<Commercial>
{
  Commercial? GetById(CommercialId id);
  Task<Commercial?> GetByIdAsync(CommercialId id);
  ICollection<Commercial> GetBuildingCommercials(BuildingId buildingId);
  Task<ICollection<Commercial>> GetBuildingCommercialsAsync(BuildingId buildingId);
  ICollection<Commercial> GetComplexCommercials(ComplexId complexId);
  Task<ICollection<Commercial>> GetComplexCommercialsAsync(ComplexId complexId);
  bool Exist(CommercialId id);
  Task<bool> ExistAsync(CommercialId id);
}