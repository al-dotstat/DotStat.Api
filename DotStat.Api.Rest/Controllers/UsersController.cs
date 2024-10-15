using System.IdentityModel.Tokens.Jwt;
using System.Net;
using DotStat.Api.Application.Auth.Commands.ChangePassword;
using DotStat.Api.Application.Auth.Commands.LoginCommand;
using DotStat.Api.Application.Auth.Commands.RefreshCommand;
using DotStat.Api.Application.Auth.Commands.RegisterCommand;
using DotStat.Api.Application.Auth.Commands.RevokeCommand;
using DotStat.Api.Application.Auth.Queries.UserQuery;
using DotStat.Api.Contracts.User;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
  [Produces("application/json")]
  [Authorize]
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetUser(int id)
  {
    var query = new UserQuery(UserId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<UserResponse>(res)),
      Problem
    );
  }

  /// <summary>
  /// Получить авторизованного пользователя
  /// </summary>
  [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [Authorize]
  [HttpGet("me")]
  public async Task<IActionResult> GetAuthUser()
  {
    var idClaim = HttpContext.User.Claims.FirstOrDefault(c =>
      c.Type == JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[JwtRegisteredClaimNames.Sub]);

    var notFoundProblem = new[] { Errors.User.UnknownUser }.ToList();
    if (idClaim is null)
      return Problem(notFoundProblem);

    if (!int.TryParse(idClaim.Value, out int id))
      return Problem(notFoundProblem);

    var query = new UserQuery(UserId.Create(id));
    var result = await _mediator.Send(query);

    return result.Match(
      res => Ok(_mapper.Map<UserResponse>(res)),
      Problem
    );
  }

  /// <summary>
  /// Зарегистрировать пользователя
  /// </summary>
  [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterRequest request)
  {
    var command = _mapper.Map<RegisterCommand>(request);
    var userResult = await _mediator.Send(command);

    return userResult.Match(
      result => base.Ok(_mapper.Map<UserResponse>(result)),
      Problem
    );
  }

  /// <summary>
  /// Авторизовать пользователя
  /// </summary>
  [ProducesResponseType(typeof(AuthenticationResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginRequest request)
  {
    var command = _mapper.Map<LoginCommand>(request);
    var authResult = await _mediator.Send(command);

    return authResult.Match(
      result => Ok(_mapper.Map<AuthenticationResponse>(result)),
      Problem
    );
  }

  /// <summary>
  /// Обновить JWT по Refresh Token
  /// </summary>
  [ProducesResponseType(typeof(RefreshResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [HttpPost("refresh")]
  public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
  {
    var command = _mapper.Map<RefreshCommand>(request);
    var authResult = await _mediator.Send(command);

    return authResult.Match(
      result => Ok(_mapper.Map<RefreshResponse>(result)),
      Problem
    );
  }

  /// <summary>
  /// Выход пользователя из системы
  /// </summary>
  [ProducesResponseType((int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [Authorize]
  [HttpPost("logout")]
  public async Task<IActionResult> Logout([FromBody] RefreshRequest request)
  {
    var idClaim = HttpContext.User.Claims.FirstOrDefault(c =>
      c.Type == JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[JwtRegisteredClaimNames.Sub]);

    var notFoundProblem = new[] { Errors.User.UnknownUser }.ToList();
    if (idClaim is null)
      return Problem(notFoundProblem);

    if (!int.TryParse(idClaim.Value, out int id))
      return Problem(notFoundProblem);

    var userId = UserId.Create(id);
    var command = new RevokeCommand(userId, request.RefreshToken);
    var result = await _mediator.Send(command);

    return result.Match(
      res => Ok(),
      Problem
    );
  }

  /// <summary>
  /// Изменить пароль пользователя
  /// </summary>
  [ProducesResponseType(typeof(AuthenticationResponse), (int)HttpStatusCode.OK)]
  [Produces("application/json")]
  [Authorize]
  [HttpPut("password")]
  public async Task<IActionResult> ChangePassword([FromBody] PasswordRequest request)
  {
    var idClaim = HttpContext.User.Claims.FirstOrDefault(c =>
      c.Type == JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[JwtRegisteredClaimNames.Sub]);

    var notFoundProblem = new[] { Errors.User.UnknownUser }.ToList();
    if (idClaim is null)
      return Problem(notFoundProblem);

    if (!int.TryParse(idClaim.Value, out int id))
      return Problem(notFoundProblem);

    var userId = UserId.Create(id);
    var command = new ChangePasswordCommand(userId, request.Password);
    var authResult = await _mediator.Send(command);

    return authResult.Match(
      result => Ok(_mapper.Map<AuthenticationResponse>(result)),
      Problem
    );
  }
}