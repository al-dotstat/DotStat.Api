using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class ComplexRepository(DotStatApiDbContext dbContext) : Repository<Complex>(dbContext), IComplexRepository
{
  public bool Exist(ComplexId id)
  {
    return _dbContext.Complexes.Any(c => c.Id == id);
  }

  public Task<bool> ExistAsync(ComplexId id)
  {
    return _dbContext.Complexes.AnyAsync(c => c.Id == id);
  }

  public ICollection<Complex> GetAllComplexes()
  {
    return [.. _dbContext.Complexes];
  }

  public async Task<ICollection<Complex>> GetAllComplexesAsync()
  {
    return await _dbContext.Complexes.ToListAsync();
  }

  public Complex? GetById(ComplexId id)
  {
    return _dbContext.Complexes.Find(id);
  }

  public async Task<Complex?> GetByIdAsync(ComplexId id)
  {
    return await _dbContext.Complexes.FindAsync(id);
  }

  public ICollection<Complex> GetDeveloperComplexes(DeveloperId developerId)
  {
    return [..
      _dbContext.Complexes
        .Where(c => c.Developers.Any(cd => cd.DeveloperId == developerId))
    ];
  }

  public async Task<ICollection<Complex>> GetDeveloperComplexesAsync(DeveloperId developerId)
  {
    return await _dbContext.Complexes
      .Where(c => c.Developers.Any(cd => cd.DeveloperId == developerId))
      .ToListAsync();
  }

  public ICollection<Complex> GetDistrictComplexes(DistrictId districtId)
  {
    return [..
      _dbContext.Complexes
        .Where(c => c.DistrictId == districtId)
    ];
  }

  public async Task<ICollection<Complex>> GetDistrictComplexesAsync(DistrictId districtId)
  {
    return await _dbContext.Complexes
      .Where(c => c.DistrictId == districtId)
      .ToListAsync();
  }

  public ICollection<Complex> Search(string search)
  {
    return [..
      _dbContext.Complexes
        .Where(c => c.NameRu.Contains(search, StringComparison.CurrentCultureIgnoreCase))
        .Take(3)
    ];
  }

  public async Task<ICollection<Complex>> SearchAsync(string search)
  {
    return await _dbContext.Complexes
      .Where(c => c.NameRu.Contains(search, StringComparison.CurrentCultureIgnoreCase))
      .Take(3)
      .ToListAsync();
  }

  public ICollection<Complex> SearchByFilters(IEnumerable<DeveloperId> developerIds, IEnumerable<DistrictId> districtIds, string name)
  {
    var searchQuery = (IQueryable<Complex>)_dbContext.Complexes;

    if (string.IsNullOrEmpty(name))
      searchQuery = searchQuery.Where(c => c.NameRu.Contains(name, StringComparison.CurrentCultureIgnoreCase));

    if (developerIds.Any())
      searchQuery = searchQuery.Where(c => c.Developers.Any(cd => developerIds.Contains(cd.DeveloperId)));

    if (districtIds.Any())
      searchQuery = searchQuery.Where(c => districtIds.Contains(c.DistrictId));

    return [.. searchQuery];
  }

  public async Task<ICollection<Complex>> SearchByFiltersAsync(IEnumerable<DeveloperId> developerIds, IEnumerable<DistrictId> districtIds, string name)
  {
    var searchQuery = (IQueryable<Complex>)_dbContext.Complexes;

    if (string.IsNullOrEmpty(name))
      searchQuery = searchQuery.Where(c => c.NameRu.Contains(name, StringComparison.CurrentCultureIgnoreCase));

    if (developerIds.Any())
      searchQuery = searchQuery.Where(c => c.Developers.Any(cd => developerIds.Contains(cd.DeveloperId)));

    if (districtIds.Any())
      searchQuery = searchQuery.Where(c => districtIds.Contains(c.DistrictId));

    return await searchQuery.ToListAsync();
  }
}
