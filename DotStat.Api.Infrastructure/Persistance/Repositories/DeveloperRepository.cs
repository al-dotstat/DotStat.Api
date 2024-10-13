using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class DeveloperRepository(DotStatApiDbContext dbContext) : Repository<Developer>(dbContext), IDeveloperRepository
{
  public ICollection<Developer> GetAll()
  {
    return [.. _dbContext.Developers];
  }

  public async Task<ICollection<Developer>> GetAllAsync()
  {
    return await _dbContext.Developers.ToListAsync();
  }

  public Developer? GetById(DeveloperId id)
  {
    return _dbContext.Developers.Find(id);
  }

  public async Task<Developer?> GetByIdAsync(DeveloperId id)
  {
    return await _dbContext.Developers.FindAsync(id);
  }
}
