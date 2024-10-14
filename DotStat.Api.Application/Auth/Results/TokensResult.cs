namespace DotStat.Api.Application.Auth.Results;

public record TokensResult(
  string Token,
  string RefreshToken
);