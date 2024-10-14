using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.OrderAggregate;
using DotStat.Api.Domain.OrderAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Commands.OrderCommands;

public class CreateOrderCommandHandler(IOrderRepository orderRepository, IUserRepository userRepository) : IRequestHandler<CreateOrderCommand, ErrorOr<OrderResult>>
{
  public async Task<ErrorOr<OrderResult>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
  {
    if (!await userRepository.ExistAsync(request.UserId))
      return Errors.User.UnknownUser;

    var orderItems = request.Items.Select(item => OrderItem.Create(
      item.ComplexId,
      item.IncludeFlats,
      item.IncludeParkings,
      item.IncludeStorages,
      item.IncludeCommercials));

    var order = Order.Create(
      request.UserId,
      Guid.NewGuid().ToString().Replace("-", string.Empty),
      DateTime.UtcNow.AddDays(3),
      orderItems
    );

    await orderRepository.AddAsync(order);
    await orderRepository.SaveChangesAsync();

    return new OrderResult(order);
  }
}
