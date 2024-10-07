using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.ParkingAggregate.ValueObjects;

public class ParkingDeclarationId : ValueObject
{
  public int Value { get; }

  private ParkingDeclarationId(int value)
  {
    Value = value;
  }

  public static ParkingDeclarationId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}