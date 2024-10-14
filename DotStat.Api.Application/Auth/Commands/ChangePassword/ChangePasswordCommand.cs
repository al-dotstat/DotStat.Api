using DotStat.Api.Application.Auth.Results;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Commands.ChangePassword;

public record ChangePasswordCommand(
  UserId UserId,
  string Password
) : IRequest<ErrorOr<AuthenticationResult>>;