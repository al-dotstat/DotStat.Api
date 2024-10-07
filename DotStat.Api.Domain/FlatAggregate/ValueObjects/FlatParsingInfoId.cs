using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.FlatAggregate.ValueObjects;

public class FlatParsingInfoId : ValueObject
{
  public int Value { get; }

  private FlatParsingInfoId(int value)
  {
    Value = value;
  }

  public static FlatParsingInfoId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}