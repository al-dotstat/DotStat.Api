using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.CommercialAggregate.ValueObjects;

public sealed class CommercialId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private CommercialId(int value)
  {
    Value = value;
  }

  public static CommercialId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}