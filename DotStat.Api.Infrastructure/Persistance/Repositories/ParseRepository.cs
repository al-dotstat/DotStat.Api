using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class ParseRepository(DotStatApiDbContext dbContext) : Repository<Parse>(dbContext), IParseRepository
{
  public bool Exist(ParseId id)
  {
    return _dbContext.Parses.Any(p => p.Id == id);
  }

  public async Task<bool> ExistAsync(ParseId id)
  {
    return await _dbContext.Parses.AnyAsync(p => p.Id == id);
  }

  public Parse? GetById(ParseId id)
  {
    return _dbContext.Parses.Find(id);
  }

  public async Task<Parse?> GetByIdAsync(ParseId id)
  {
    return await _dbContext.Parses.FindAsync(id);
  }

  public ICollection<Parse> GetComplexParses(ComplexId complexId)
  {
    return [..
      _dbContext.Parses
        .Where(p => p.ComplexId == complexId)
    ];
  }

  public async Task<ICollection<Parse>> GetComplexParsesAsync(ComplexId complexId)
  {
    return await _dbContext.Parses.Where(p => p.ComplexId == complexId).ToListAsync();
  }
}
