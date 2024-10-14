using DotStat.Api.Application.Auth.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Commands.RegisterCommand;

public record RegisterCommand(
  string FirstName,
  string Email,
  string Password
) : IRequest<ErrorOr<UserResult>>;