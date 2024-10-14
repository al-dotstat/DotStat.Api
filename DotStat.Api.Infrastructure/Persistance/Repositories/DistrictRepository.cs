using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.DistrictAggregate;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class DistrictRepository(DotStatApiDbContext dbContext) : Repository<District>(dbContext), IDistrictRepository
{
  public bool Exist(DistrictId id)
  {
    return _dbContext.Districts.Any(d => d.Id == id);
  }

  public async Task<bool> ExistAsync(DistrictId id)
  {
    return await _dbContext.Districts.AnyAsync(d => d.Id == id);
  }

  public ICollection<District> GetAll()
  {
    return [.. _dbContext.Districts];
  }

  public async Task<ICollection<District>> GetAllAsync()
  {
    return await _dbContext.Districts.ToListAsync();
  }

  public District? GetById(DistrictId id)
  {
    return _dbContext.Districts.Find(id);
  }

  public async Task<District?> GetByIdAsync(DistrictId id)
  {
    return await _dbContext.Districts.FindAsync(id);
  }
}
