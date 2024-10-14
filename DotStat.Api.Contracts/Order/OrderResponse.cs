namespace DotStat.Api.Contracts.Order;

public record OrderResponse(
  int Id,
  int UserId,
  OrderItemResponse[] Items,
  string FileName,
  DateTime FileExpiredDateTime,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);