using ErrorOr;

namespace DotStat.Api.Domain.Common.Errors;

public static partial class Errors
{
  public static class User
  {
    public static Error UnknownUser => Error.NotFound(nameof(UnknownUser), "Пользователь не найден");
    public static Error UnknownRefreshToken => Error.NotFound(nameof(UnknownRefreshToken), "Refresh Token не найден");
    public static Error EmailAlreadyRegistered => Error.Conflict(nameof(EmailAlreadyRegistered), "Почта уже зарегистрирована");
    public static Error InvalidCredentials => Error.Failure(nameof(InvalidCredentials), "Неверные данные для входа");
  }
}