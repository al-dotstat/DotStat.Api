namespace DotStat.Api.Contracts.District;

public record DistrictResponse(
  int Id,
  string Name,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);