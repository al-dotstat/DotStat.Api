using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Queries.OrderQueries;

public record UserOrdersQuery(
  UserId UserId
) : IRequest<ErrorOr<OrdersResult>>;