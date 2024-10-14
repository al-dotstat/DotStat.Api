using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.OrderAggregate;
using DotStat.Api.Domain.OrderAggregate.ValueObjects;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class OrderRepository(DotStatApiDbContext dbContext) : Repository<Order>(dbContext), IOrderRepository
{
  public bool Exist(OrderId id)
  {
    return _dbContext.Orders.Any(o => o.Id == id);
  }

  public async Task<bool> ExistAsync(OrderId id)
  {
    return await _dbContext.Orders.AnyAsync(o => o.Id == id);
  }

  public Order? GetById(OrderId id)
  {
    return _dbContext.Orders.Find(id);
  }

  public async Task<Order?> GetByIdAsync(OrderId id)
  {
    return await _dbContext.Orders.FindAsync(id);
  }

  public ICollection<Order> GetUserOrders(UserId userId)
  {
    return [..
      _dbContext.Orders
        .Where(o => o.UserId == userId)
    ];
  }

  public async Task<ICollection<Order>> GetUserOrdersAsync(UserId userId)
  {
    return await _dbContext.Orders
      .Where(o => o.UserId == userId)
      .ToListAsync();
  }
}
