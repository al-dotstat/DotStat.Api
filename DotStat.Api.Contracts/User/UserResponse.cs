namespace DotStat.Api.Contracts.User;

public record UserResponse(
  int Id,
  string FirstName,
  string? LastName,
  string? MiddleName,
  string Email
);