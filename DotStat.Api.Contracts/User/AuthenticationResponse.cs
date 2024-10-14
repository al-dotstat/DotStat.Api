namespace DotStat.Api.Contracts.User;

public record AuthenticationResponse(
  UserResponse User,
  RefreshResponse Tokens
);