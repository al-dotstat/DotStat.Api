namespace DotStat.Api.Contracts.User;

public record RefreshResponse(
  string Token,
  string RefreshToken
);