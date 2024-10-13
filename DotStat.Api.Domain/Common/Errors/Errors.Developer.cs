using ErrorOr;

namespace DotStat.Api.Domain.Common.Errors;

public static partial class Errors
{
  public static class Developer
  {
    public static Error UnknownDeveloper => Error.NotFound(nameof(UnknownDeveloper), "Застройщик не найден");
  }
}