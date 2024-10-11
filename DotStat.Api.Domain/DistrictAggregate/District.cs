using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;

namespace DotStat.Api.Domain.DistrictAggregate;

public sealed class District : AggregateRoot<DistrictId, int>
{
  public string Name { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private District(string name, DateTime createdDateTime, DateTime updatedDateTime)
  {
    Name = name;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static District Create(string name)
  {
    return new District(name, DateTime.UtcNow, DateTime.UtcNow);
  }

#pragma warning disable CS8618
  private District()
  {
  }
#pragma warning restore CS8618
}