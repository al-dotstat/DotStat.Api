using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.ParkingAggregate.ValueObjects;

public sealed class ParkingId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private ParkingId(int value)
  {
    Value = value;
  }

  public static ParkingId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}