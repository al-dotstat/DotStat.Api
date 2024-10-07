using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;

namespace DotStat.Api.Domain.BuildingAggregate;

public sealed class Building : AggregateRoot<BuildingId, int>
{
  public string Name { get; private set; }
  public ComplexId ComplexId { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Building(
    string name,
    ComplexId complexId,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    Name = name;
    ComplexId = complexId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Building Create(string name, ComplexId complexId)
  {
    return new(
      name,
      complexId,
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

  public void SetName(string name)
  {
    Name = name;
    UpdatedDateTime = DateTime.UtcNow;
  }

#pragma warning disable CS8618
  private Building()
  {
  }
#pragma warning restore CS8618
}