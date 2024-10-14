using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.UserAggregate.ValueObjects;

public class UserClaimId : ValueObject
{
  public int Value { get; }

  private UserClaimId(int value)
  {
    Value = value;
  }

  public static UserClaimId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}