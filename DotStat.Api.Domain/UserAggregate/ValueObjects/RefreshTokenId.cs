using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.UserAggregate.ValueObjects;

public sealed class RefreshTokenId : ValueObject
{
  public string Value { get; }

  private RefreshTokenId(string value)
  {
    Value = value;
  }

  public static RefreshTokenId CreateUnique()
  {
    return new(Guid.NewGuid().ToString().Replace("-", string.Empty));
  }

  public static RefreshTokenId Create(string value)
  {
    return new(value);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}