namespace DotStat.Api.Contracts.User;

public record LoginRequest(
  string Email,
  string Password
);