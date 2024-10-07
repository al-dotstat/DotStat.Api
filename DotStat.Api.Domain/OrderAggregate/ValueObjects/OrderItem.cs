using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;

namespace DotStat.Api.Domain.OrderAggregate.ValueObjects;

public sealed class OrderItem : ValueObject
{
  public ComplexId ComplexId { get; private set; }
  public bool IncludeFlats { get; private set; }
  public bool IncludeParkings { get; private set; }
  public bool IncludeStorages { get; private set; }
  public bool IncludeCommercials { get; private set; }

  private OrderItem(ComplexId complexId, bool includeFlats, bool includeParkings, bool includeStorages, bool includeCommercials)
  {
    ComplexId = complexId;
    IncludeFlats = includeFlats;
    IncludeParkings = includeParkings;
    IncludeStorages = includeStorages;
    IncludeCommercials = includeCommercials;
  }

  public static OrderItem Create(ComplexId complexId, bool includeFlats, bool includeParkings, bool includeStorages, bool includeCommercials)
  {
    return new OrderItem(complexId, includeFlats, includeParkings, includeStorages, includeCommercials);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return ComplexId;
    yield return IncludeFlats;
    yield return IncludeParkings;
    yield return IncludeStorages;
    yield return IncludeCommercials;
  }

#pragma warning disable CS8618
  private OrderItem()
  {
  }
#pragma warning restore CS8618
}