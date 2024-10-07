using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;

namespace DotStat.Api.Domain.ComplexAggregate.Entities;

public class District : Entity<DistrictId>
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
    return new(name, DateTime.UtcNow, DateTime.UtcNow);
  }

#pragma warning disable CS8618
  private District()
  {
  }
#pragma warning restore CS8618
}