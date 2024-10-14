namespace DotStat.Api.Contracts.User;

public record RegisterRequest(
  string FirstName,
  string Email,
  string Password
);