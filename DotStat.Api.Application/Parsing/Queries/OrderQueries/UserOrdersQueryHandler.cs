using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Queries.OrderQueries;

public class UserOrdersQueryHandler(IUserRepository userRepository, IOrderRepository orderRepository) : IRequestHandler<UserOrdersQuery, ErrorOr<OrdersResult>>
{
  public async Task<ErrorOr<OrdersResult>> Handle(UserOrdersQuery request, CancellationToken cancellationToken)
  {
    if (!await userRepository.ExistAsync(request.UserId))
      return Errors.User.UnknownUser;

    var orders = await orderRepository.GetUserOrdersAsync(request.UserId);
    return new OrdersResult(orders);
  }
}
