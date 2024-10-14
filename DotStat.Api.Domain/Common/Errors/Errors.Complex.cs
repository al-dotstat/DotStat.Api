using ErrorOr;

namespace DotStat.Api.Domain.Common.Errors;

public static partial class Errors
{
  public static class Complex
  {
    public static Error UnknownComplex => Error.NotFound(nameof(UnknownComplex), "ЖК не найден");
  }
}