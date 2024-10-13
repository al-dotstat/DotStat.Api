using DotStat.Api.Application.Common.Interfaces.Persistance;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
  protected readonly DotStatApiDbContext _dbContext;

  public Repository(DotStatApiDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public virtual void Add(T entity)
  {
    _dbContext.Add(entity);
  }

  public async Task AddAsync(T entity)
  {
    await _dbContext.AddAsync(entity);
  }

  public virtual void AddRange(IEnumerable<T> entities)
  {
    _dbContext.AddRange(entities);
  }

  public async Task AddRangeAsync(IEnumerable<T> entities)
  {
    await _dbContext.AddRangeAsync(entities);
  }

  public virtual void Delete(T entity)
  {
    _dbContext.Remove(entity);
  }

  public virtual void DeleteRange(IEnumerable<T> entities)
  {
    _dbContext.RemoveRange(entities);
  }

  public void SaveChanges()
  {
    _dbContext.SaveChanges();
  }

  public async Task SaveChangesAsync()
  {
    await _dbContext.SaveChangesAsync();
  }

  public virtual void Update(T entity)
  {
    _dbContext.Update(entity);
  }

  public virtual void UpdateRange(IEnumerable<T> entities)
  {
    _dbContext.UpdateRange(entities);
  }
}