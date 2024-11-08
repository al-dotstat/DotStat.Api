using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;

namespace DotStat.Api.Domain.DeveloperAggregate;

public sealed class Developer : AggregateRoot<DeveloperId, int>
{
  public string Name { get; private set; }
  public string NameRu { get; private set; }
  public string? ImageFilePath { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Developer(
    string name,
    string nameRu,
    string? imageFilePath,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    Name = name;
    NameRu = nameRu;
    ImageFilePath = imageFilePath;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Developer Create(
    string name,
    string nameRu,
    string? imageFilePath
  )
  {
    return new(
      name,
      nameRu,
      imageFilePath,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }

#pragma warning disable CS8618
  private Developer()
  {
  }
#pragma warning restore CS8618
}