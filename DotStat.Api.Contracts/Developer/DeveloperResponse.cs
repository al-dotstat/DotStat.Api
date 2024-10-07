namespace DotStat.Api.Contracts.Developer;

public record DeveloperResponse(
  int Id,
  string Name,
  string NameRu,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);