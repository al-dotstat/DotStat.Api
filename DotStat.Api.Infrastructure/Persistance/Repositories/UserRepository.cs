using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.UserAggregate;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class UserRepository(DotStatApiDbContext dbContext) : Repository<User>(dbContext), IUserRepository
{
  public bool Exist(UserId id)
  {
    return _dbContext.Users.Any(u => u.Id == id);
  }

  public bool Exist(string email)
  {
    return _dbContext.Users.Any(u => u.Email == email);
  }

  public async Task<bool> ExistAsync(UserId id)
  {
    return await _dbContext.Users.AnyAsync(u => u.Id == id);
  }

  public async Task<bool> ExistAsync(string email)
  {
    return await _dbContext.Users.AnyAsync(u => u.Email == email);
  }

  public User? GetByEmail(string email)
  {
    return _dbContext.Users.FirstOrDefault(u => u.Email == email);
  }

  public async Task<User?> GetByEmailAsync(string email)
  {
    return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
  }

  public User? GetById(UserId id)
  {
    return _dbContext.Users.Find(id);
  }

  public async Task<User?> GetByIdAsync(UserId id)
  {
    return await _dbContext.Users.FindAsync(id);
  }

  public User? GetByRefreshToken(string refreshToken)
  {
    var refreshTokenId = RefreshTokenId.Create(refreshToken);
    return _dbContext.Users.FirstOrDefault(u => u.RefreshTokens.Any(rt => rt.Id == refreshTokenId));
  }

  public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
  {
    var refreshTokenId = RefreshTokenId.Create(refreshToken);
    return await _dbContext.Users.FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.Id == refreshTokenId));
  }
}
