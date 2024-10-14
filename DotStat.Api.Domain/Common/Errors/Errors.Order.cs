using ErrorOr;

namespace DotStat.Api.Domain.Common.Errors;

public static partial class Errors
{
  public static class Order
  {
    public static Error UnknownOrder => Error.NotFound(nameof(UnknownOrder), "Заказ не найден");
  }
}