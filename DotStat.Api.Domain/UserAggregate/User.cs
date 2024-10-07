using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.UserAggregate.Entities;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace DotStat.Api.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId, int>
{
  private readonly List<RefreshToken> _refreshTokens = [];

  public string FirstName { get; private set; }
  public string? LastName { get; private set; }
  public string? MiddleName { get; private set; }
  public string Email { get; private set; }
  public string PasswordHash { get; private set; }

  public IReadOnlyList<RefreshToken> RefreshTokens => _refreshTokens.ToList().AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private User(
    string firstName,
    string? lastName,
    string? middleName,
    string email,
    string passwordHash,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    FirstName = firstName;
    LastName = lastName;
    MiddleName = middleName;
    Email = email;
    PasswordHash = passwordHash;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static User Create(
    string firstName,
    string? lastName,
    string? middleName,
    string email,
    string password
  )
  {
    var passwordHash = new PasswordHasher<User>().HashPassword(null!, password);
    var user = new User(
      firstName,
      lastName,
      middleName,
      email,
      passwordHash,
      DateTime.UtcNow,
      DateTime.UtcNow);

    return user;
  }

  public void ChangePassword(string password)
  {
    var passwordHash = new PasswordHasher<User>().HashPassword(null!, password);
    PasswordHash = passwordHash;
    _refreshTokens.Clear();
    UpdatedDateTime = DateTime.UtcNow;
  }

  public void AddRefreshToken(RefreshToken refreshToken)
  {
    _refreshTokens.Add(refreshToken);
    UpdatedDateTime = DateTime.UtcNow;
  }

  public void RemoveRefreshToken(RefreshToken refreshToken)
  {
    _refreshTokens.Remove(refreshToken);
    UpdatedDateTime = DateTime.UtcNow;
  }

#pragma warning disable CS8618
  private User()
  {
  }
#pragma warning restore CS8618
}