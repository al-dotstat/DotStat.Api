namespace DotStat.Api.Contracts.Developer;

public record DeveloperResponse(
  int Id,
  string Name,
  string NameRu,
  string? ImageFilePath,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);