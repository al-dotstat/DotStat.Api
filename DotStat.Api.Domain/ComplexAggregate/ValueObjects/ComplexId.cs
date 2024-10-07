using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.ComplexAggregate.ValueObjects;

public sealed class ComplexId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private ComplexId(int value)
  {
    Value = value;
  }

  public static ComplexId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}