using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.DeveloperAggregate.ValueObjects;

public sealed class DeveloperId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private DeveloperId(int value)
  {
    Value = value;
  }

  public static DeveloperId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}