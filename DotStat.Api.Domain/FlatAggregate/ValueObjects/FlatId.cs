using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.FlatAggregate.ValueObjects;

public sealed class FlatId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private FlatId(int value)
  {
    Value = value;
  }

  public static FlatId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}