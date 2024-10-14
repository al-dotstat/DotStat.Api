using ErrorOr;

namespace DotStat.Api.Domain.Common.Errors;

public static partial class Errors
{
  public static class Building
  {
    public static Error UnknownBuilding => Error.NotFound(nameof(UnknownBuilding), "Здание не найдено");
  }
}