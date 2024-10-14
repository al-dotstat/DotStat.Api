using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.OrderAggregate;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Queries.OrderQueries;

public class OrderQueryHandler(IOrderRepository orderRepository) : IRequestHandler<OrderQuery, ErrorOr<OrderResult>>
{
  public async Task<ErrorOr<OrderResult>> Handle(OrderQuery request, CancellationToken cancellationToken)
  {
    if (await orderRepository.GetByIdAsync(request.OrderId) is not Order order)
      return Errors.Order.UnknownOrder;

    return new OrderResult(order);
  }
}
