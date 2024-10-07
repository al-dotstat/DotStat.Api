using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.ComplexAggregate.ValueObjects;

public class DistrictId : ValueObject
{
  public int Value { get; }

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