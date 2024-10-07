using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;

namespace DotStat.Api.Domain.ComplexAggregate.Entities;

public class Metro : Entity<MetroId>
{
  public string Name { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Metro(string name, DateTime createdDateTime, DateTime updatedDateTime)
  {
    Name = name;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Metro Create(string name)
  {
    return new(name, DateTime.UtcNow, DateTime.UtcNow);
  }

#pragma warning disable CS8618
  private Metro()
  {
  }
#pragma warning restore CS8618
}