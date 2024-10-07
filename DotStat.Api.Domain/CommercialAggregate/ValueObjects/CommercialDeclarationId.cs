using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.CommercialAggregate.ValueObjects;

public class CommercialDeclarationId : ValueObject
{
  public int Value { get; }

  private CommercialDeclarationId(int value)
  {
    Value = value;
  }

  public static CommercialDeclarationId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}