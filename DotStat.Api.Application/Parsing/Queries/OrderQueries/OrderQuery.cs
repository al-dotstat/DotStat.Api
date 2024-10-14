using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.OrderAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Queries.OrderQueries;

public record OrderQuery(
  OrderId OrderId
) : IRequest<ErrorOr<OrderResult>>;