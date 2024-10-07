using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.StorageAggregate.ValueObjects;

public class StorageDeclarationId : ValueObject
{
  public int Value { get; }

  private StorageDeclarationId(int value)
  {
    Value = value;
  }

  public static StorageDeclarationId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}