using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.OrderAggregate.ValueObjects;
using DotStat.Api.Domain.UserAggregate.ValueObjects;

namespace DotStat.Api.Domain.OrderAggregate;

public sealed class Order : AggregateRoot<OrderId, int>
{
  private List<OrderItem> _orderItems = [];

  public UserId UserId { get; private set; }
  public string FileName { get; private set; }
  public DateTime FileExpiredDateTime { get; private set; }

  public IReadOnlyList<OrderItem> OrderItems => _orderItems.ToList().AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Order(
    UserId userId,
    string fileName,
    DateTime fileExpiredDateTime,
    IEnumerable<OrderItem> items,
    DateTime updatedDateTime,
    DateTime createdDateTime
  )
  {
    UserId = userId;
    FileName = fileName;
    FileExpiredDateTime = fileExpiredDateTime;
    _orderItems = items.ToList();
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Order Create(
    UserId userId,
    string fileName,
    DateTime fileExpiredDateTime,
    IEnumerable<OrderItem> items
  )
  {
    return new(
      userId,
      fileName,
      fileExpiredDateTime,
      items,
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

#pragma warning disable CS8618
  private Order()
  {
  }
#pragma warning restore CS8618
}