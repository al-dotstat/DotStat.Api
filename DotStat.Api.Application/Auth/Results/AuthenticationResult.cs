using DotStat.Api.Domain.UserAggregate;

namespace DotStat.Api.Application.Auth.Results;

public record AuthenticationResult(
  User User,
  string Token,
  string RefreshToken
);