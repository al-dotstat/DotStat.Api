using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.OrderAggregate.ValueObjects;

public sealed class OrderId : AggregateRootId<int>
{
  public override int Value { get; protected set; }

  private OrderId(int value)
  {
    Value = value;
  }

  public static OrderId Create(int value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}