using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.ParkingAggregate.ValueObjects;

public sealed class ParkingParsingInfoId : ValueObject
{
  public int Value { get; }

  private ParkingParsingInfoId(int value)
  {
    Value = value;
  }

  public static ParkingParsingInfoId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}