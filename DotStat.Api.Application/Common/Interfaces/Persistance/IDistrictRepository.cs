using DotStat.Api.Domain.DistrictAggregate;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IDistrictRepository : IRepository<District>
{
  District? GetById(DistrictId id);
  Task<District?> GetByIdAsync(DistrictId id);
  ICollection<District> GetAll();
  Task<ICollection<District>> GetAllAsync();
  bool Exist(DistrictId id);
  Task<bool> ExistAsync(DistrictId id);
}