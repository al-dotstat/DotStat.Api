using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.UserAggregate.ValueObjects;

namespace DotStat.Api.Domain.UserAggregate.Entities;

public sealed class UserClaim : Entity<UserClaimId>
{
  public string Type { get; private set; }
  public string Value { get; private set; }

  private UserClaim(string type, string value)
  {
    Type = type;
    Value = value;
  }

  public static UserClaim Create(string type, string value)
  {
    return new(type, value);
  }

#pragma warning disable CS8618
  private UserClaim()
  {
  }
#pragma warning restore CS8618
}