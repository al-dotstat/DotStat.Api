using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.StorageAggregate.ValueObjects;

public sealed class StorageId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private StorageId(int value)
  {
    Value = value;
  }

  public static StorageId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}