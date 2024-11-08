namespace DotStat.Api.Contracts.Complex;

public record ComplexResponse(
  int Id,
  string Name,
  string NameRu,
  string? Description,
  string? Address,
  string? Latitude,
  string? Longitude,
  double? Area,
  string? ImageFilePath,
  DateTime? CompletionDate,
  int DistrictId,
  ComplexDeveloperResponse[] Developers,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);