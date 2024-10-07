using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.BuildingAggregate.ValueObjects;

public sealed class BuildingId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private BuildingId(int value)
  {
    Value = value;
  }

  public static BuildingId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}