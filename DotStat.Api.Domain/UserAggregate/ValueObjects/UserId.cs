using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.UserAggregate.ValueObjects;

public sealed class UserId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private UserId(int value)
  {
    Value = value;
  }

  public static UserId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}