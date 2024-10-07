namespace DotStat.Api.Contracts.Commercial;

public record CommercialParsingInfoResponse(
  int Id,
  int ParseId,
  string? Number,
  string? Floor,
  double? Area,
  string? Building,
  string? AdditionalJsonInfo,
  double Price,
  DateTime Date,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);