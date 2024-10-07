namespace DotStat.Api.Contracts.Order;

public record OrderResponse(
  int Id,
  int UserId,
  OrderItemResponse[] Items,
  DateTime FileExpiredDateTime,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);