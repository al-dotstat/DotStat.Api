using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Contracts.Common;
using DotStat.Api.Contracts.Order;
using DotStat.Api.Domain.OrderAggregate;
using DotStat.Api.Domain.OrderAggregate.ValueObjects;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class OrderMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<OrderId, int>()
      .MapWith(src => src.Value);

    config.NewConfig<OrderItem, OrderItemResponse>();

    config.NewConfig<Order, OrderResponse>();

    config.NewConfig<OrderResult, OrderResponse>()
      .Map(dest => dest, src => src.Order);

    config.NewConfig<OrdersResult, CollectionResponse<OrderResponse>>()
      .Map(dest => dest.Items, src => src.Orders);
  }
}
