using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IDeveloperRepository : IRepository<Developer>
{
  Developer? GetById(DeveloperId id);
  Task<Developer?> GetByIdAsync(DeveloperId id);
  ICollection<Developer> GetAll();
  Task<ICollection<Developer>> GetAllAsync();
}