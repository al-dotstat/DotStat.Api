using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.StorageAggregate.ValueObjects;

public sealed class StorageParsingInfoId : ValueObject
{
  public int Value { get; }

  private StorageParsingInfoId(int value)
  {
    Value = value;
  }

  public static StorageParsingInfoId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}