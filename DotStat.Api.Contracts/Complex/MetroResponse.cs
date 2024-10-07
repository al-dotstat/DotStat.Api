namespace DotStat.Api.Contracts.Complex;

public record MetroResponse(
  int Id,
  string Name,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);