namespace DotStat.Api.Contracts.User;

public record RefreshTokenResponse(
  string Token,
  string? Ip,
  string? Device,
  DateTime ExpiredDateTime
);