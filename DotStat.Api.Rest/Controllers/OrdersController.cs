using System.IdentityModel.Tokens.Jwt;
using System.Net;
using DotStat.Api.Application.Parsing.Commands.OrderCommands;
using DotStat.Api.Application.Parsing.Queries.OrderQueries;
using DotStat.Api.Contracts.Order;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.OrderAggregate.ValueObjects;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
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
    var query = new OrderQuery(OrderId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<OrderResponse>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить историю заказов авторизованного пользователя
  /// </summary>
  [ProducesResponseType(typeof(OrderResponse[]), (int)HttpStatusCode.OK)]
  [HttpGet("history")]
  public async Task<IActionResult> GetOrdersHistory()
  {
    var idClaim = HttpContext.User.Claims.FirstOrDefault(c =>
      c.Type == JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[JwtRegisteredClaimNames.Sub]);

    var notFoundProblem = new[] { Errors.User.UnknownUser }.ToList();
    if (idClaim is null)
      return Problem(notFoundProblem);

    if (!int.TryParse(idClaim.Value, out int id))
      return Problem(notFoundProblem);

    var query = new UserOrdersQuery(UserId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<OrderResponse[]>(res)),
      Problem
    );
  }

  /// <summary>
  /// Создать заказ
  /// </summary>
  [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
  [HttpPost]
  public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
  {
    var idClaim = HttpContext.User.Claims.FirstOrDefault(c =>
      c.Type == JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[JwtRegisteredClaimNames.Sub]);

    var notFoundProblem = new[] { Errors.User.UnknownUser }.ToList();
    if (idClaim is null)
      return Problem(notFoundProblem);

    if (!int.TryParse(idClaim.Value, out int id))
      return Problem(notFoundProblem);

    var orderItems = request.OrderItems.Select(item => new CreateOrderItem(
      ComplexId.Create(item.ComplexId),
      item.IncludeFlats,
      item.IncludeParkings,
      item.IncludeStorages,
      item.IncludeCommercials)
    );
    var query = new CreateOrderCommand(
      UserId.Create(id),
      orderItems
    );
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<OrderResponse[]>(res)),
      Problem
    );
  }
}