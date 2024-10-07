using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.ComplexAggregate.ValueObjects;

public class MetroId : ValueObject
{
  public int Value { get; }

  private MetroId(int value)
  {
    Value = value;
  }

  public static MetroId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}