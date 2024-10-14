using DotStat.Api.Domain.UserAggregate;
using DotStat.Api.Domain.UserAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IUserRepository : IRepository<User>
{
  User? GetById(UserId id);
  Task<User?> GetByIdAsync(UserId id);
  User? GetByEmail(string email);
  Task<User?> GetByEmailAsync(string email);
  User? GetByRefreshToken(string refreshToken);
  Task<User?> GetByRefreshTokenAsync(string refreshToken);
  bool Exist(UserId id);
  Task<bool> ExistAsync(UserId id);
  bool Exist(string email);
  Task<bool> ExistAsync(string email);
}