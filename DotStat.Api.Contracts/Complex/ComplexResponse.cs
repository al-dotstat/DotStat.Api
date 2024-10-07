namespace DotStat.Api.Contracts.Complex;

public record ComplexResponse(
  int Id,
  string Name,
  string NameRu,
  string? Address,
  string? Latitude,
  string? Longitude,
  double? Area,
  DateTime? CompletionDate,
  DistrictResponse District,
  MetroResponse Metro,
  ComplexDeveloperResponse[] Developers,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);