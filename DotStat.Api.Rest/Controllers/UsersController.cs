using System.Net;
using DotStat.Api.Contracts.User;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotStat.Api.Rest.Controllers;

public class UsersController : BaseController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public UsersController(ISender mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  /// <summary>
  /// Получить пользователя по Id
  /// </summary>
  /// <param name="id">Id пользователя</param>
  [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetUser(int id)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Получить авторизованного пользователя
  /// </summary>
  [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
  [HttpGet("me")]
  public async Task<IActionResult> GetAuthUser()
  {
    throw new NotImplementedException();
  }
}