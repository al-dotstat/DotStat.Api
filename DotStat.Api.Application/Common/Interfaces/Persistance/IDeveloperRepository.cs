using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IDeveloperRepository : IRepository<Developer>
{
  Developer? GetById(DeveloperId id);
  Task<Developer?> GetByIdAsync(DeveloperId id);
  ICollection<Developer> GetAll();
  Task<ICollection<Developer>> GetAllAsync();
  ICollection<Developer> Search(string search);
  Task<ICollection<Developer>> SearchAsync(string search);
  ICollection<Developer> GetComplexDevelopers(ComplexId complexId);
  Task<ICollection<Developer>> GetComplexDevelopersAsync(ComplexId complexId);
  bool Exist(DeveloperId id);
  Task<bool> ExistAsync(DeveloperId id);
}