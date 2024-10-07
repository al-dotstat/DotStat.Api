namespace DotStat.Api.Contracts.Building;

public record BuildingResponse(
  int Id,
  int ComplexId,
  string Name,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);