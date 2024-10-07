using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.FlatAggregate.ValueObjects;

public class FlatDeclarationId : ValueObject
{
  public int Value { get; }

  private FlatDeclarationId(int value)
  {
    Value = value;
  }

  public static FlatDeclarationId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}