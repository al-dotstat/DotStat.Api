using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;

namespace DotStat.Api.Domain.ComplexAggregate.ValueObjects;

public sealed class ComplexDeveloper : ValueObject
{
  public DeveloperId DeveloperId { get; private set; }

  private ComplexDeveloper(DeveloperId developerId)
  {
    DeveloperId = developerId;
  }

  public static ComplexDeveloper Create(DeveloperId developerId)
  {
    return new(developerId);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return DeveloperId;
  }
}