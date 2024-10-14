using ErrorOr;

namespace DotStat.Api.Domain.Common.Errors;

public static partial class Errors
{
  public static class District
  {
    public static Error UnknownDistrict => Error.NotFound(nameof(UnknownDistrict), "Район не найден");
  }
}