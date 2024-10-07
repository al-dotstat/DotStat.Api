using System.Net;
using DotStat.Api.Contracts.Order;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

public class OrdersController : BaseController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public OrdersController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  /// <summary>
  /// Получить заказ по Id
  /// </summary>
  /// <param name="id">Id заказа</param>
  [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetOrder(int id)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить историю заказов авторизованного пользователя
  /// </summary>
  /// <param name="page">Страница</param>
  /// <param name="id">Id заказа</param>
  [ProducesResponseType(typeof(OrderResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet("history")]
  public async Task<IActionResult> GetOrdersHistory([FromQuery] int page)
  {
    throw new NotImplementedException();
  }
}