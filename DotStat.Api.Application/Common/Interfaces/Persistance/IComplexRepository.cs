using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IComplexRepository : IRepository<Complex>
{
  Complex? GetById(ComplexId id);
  Task<Complex?> GetByIdAsync(ComplexId id);
  ICollection<Complex> GetDeveloperComplexes(DeveloperId developerId);
  Task<ICollection<Complex>> GetDeveloperComplexesAsync(DeveloperId developerId);
  ICollection<Complex> GetDistrictComplexes(DistrictId districtId);
  Task<ICollection<Complex>> GetDistrictComplexesAsync(DistrictId districtId);
  ICollection<Complex> GetAllComplexes();
  Task<ICollection<Complex>> GetAllComplexesAsync();
  ICollection<Complex> Search(string search);
  Task<ICollection<Complex>> SearchAsync(string search);
  ICollection<Complex> SearchByFilters(
    IEnumerable<DeveloperId> developerIds,
    IEnumerable<DistrictId> districtIds,
    string name
  );
  Task<ICollection<Complex>> SearchByFiltersAsync(
    IEnumerable<DeveloperId> developerIds,
    IEnumerable<DistrictId> districtIds,
    string name
  );
  bool Exist(ComplexId id);
  Task<bool> ExistAsync(ComplexId id);
}