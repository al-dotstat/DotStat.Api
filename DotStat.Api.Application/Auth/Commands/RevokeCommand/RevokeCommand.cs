using DotStat.Api.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Commands.RevokeCommand;

public record RevokeCommand(
  UserId UserId,
  string RefreshToken
) : IRequest<ErrorOr<bool>>;