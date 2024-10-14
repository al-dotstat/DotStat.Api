using DotStat.Api.Application.Auth.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Commands.LoginCommand;

public record LoginCommand(
  string Email,
  string Password
) : IRequest<ErrorOr<AuthenticationResult>>;