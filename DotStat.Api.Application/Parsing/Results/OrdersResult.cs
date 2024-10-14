using DotStat.Api.Domain.OrderAggregate;

namespace DotStat.Api.Application.Parsing.Results;

public record OrdersResult(
  IEnumerable<Order> Orders
);