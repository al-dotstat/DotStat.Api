using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.DistrictAggregate.ValueObjects;

public sealed class DistrictId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private DistrictId(int value)
  {
    Value = value;
  }

  public static DistrictId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}