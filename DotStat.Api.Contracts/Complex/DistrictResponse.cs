namespace DotStat.Api.Contracts.Complex;

public record DistrictResponse(
  int Id,
  string Name,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);