using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.ParseAggregate.ValueObjects;

public sealed class ParseId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private ParseId(int value)
  {
    Value = value;
  }

  public static ParseId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}