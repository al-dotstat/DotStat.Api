using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.UserAggregate.ValueObjects;

public class UserRoleId : ValueObject
{
  public int Value { get; }

  private UserRoleId(int value)
  {
    Value = value;
  }

  public static UserRoleId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}