using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.CommercialAggregate.ValueObjects;

public sealed class CommercialParsingInfoId : ValueObject
{
  public int Value { get; }

  private CommercialParsingInfoId(int value)
  {
    Value = value;
  }

  public static CommercialParsingInfoId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}