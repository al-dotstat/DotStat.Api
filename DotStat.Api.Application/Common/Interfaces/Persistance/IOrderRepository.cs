using DotStat.Api.Domain.OrderAggregate;
using DotStat.Api.Domain.OrderAggregate.ValueObjects;
using DotStat.Api.Domain.UserAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IOrderRepository : IRepository<Order>
{
  Order? GetById(OrderId id);
  Task<Order?> GetByIdAsync(OrderId id);
  ICollection<Order> GetUserOrders(UserId userId);
  Task<ICollection<Order>> GetUserOrdersAsync(UserId userId);
  bool Exist(OrderId id);
  Task<bool> ExistAsync(OrderId id);
}