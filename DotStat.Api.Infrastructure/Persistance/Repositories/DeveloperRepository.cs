using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class DeveloperRepository(DotStatApiDbContext dbContext) : Repository<Developer>(dbContext), IDeveloperRepository
{
  public bool Exist(DeveloperId id)
  {
    return _dbContext.Developers.Any(c => c.Id == id);
  }

  public async Task<bool> ExistAsync(DeveloperId id)
  {
    return await _dbContext.Developers.AnyAsync(c => c.Id == id);
  }

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

  public ICollection<Developer> GetComplexDevelopers(ComplexId complexId)
  {
    var developerIds = _dbContext.Complexes
      .Find(complexId)!
      .Developers
      .Select(d => d.DeveloperId);

    return [..
      _dbContext.Developers.Where(d => developerIds.Any(did => did == d.Id))
    ];
  }

  public async Task<ICollection<Developer>> GetComplexDevelopersAsync(ComplexId complexId)
  {
    var developerIds = _dbContext.Complexes
      .Find(complexId)!
      .Developers
      .Select(d => d.DeveloperId);

    return await _dbContext.Developers
      .Where(d => developerIds.Any(did => did == d.Id))
      .ToListAsync();
  }

  public ICollection<Developer> Search(string search)
  {
    return [..
      _dbContext.Developers
        .Where(d => EF.Functions.Like(d.NameRu.ToLower(), $"%{search.ToLower()}%"))
        .Take(3)
    ];
  }

  public async Task<ICollection<Developer>> SearchAsync(string search)
  {
    return await _dbContext.Developers
      .Where(d => EF.Functions.Like(d.NameRu.ToLower(), $"%{search.ToLower()}%"))
      .Take(3)
      .ToListAsync();
  }
}
