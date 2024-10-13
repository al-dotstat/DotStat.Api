using DotStat.Api.Domain.Common.Enums;

namespace DotStat.Api.Contracts.Flat;

public record FlatParsingInfoResponse(
  int Id,
  int ParseId,
  string? Number,
  string? Roominess,
  string? Floor,
  double? Area,
  double? LivingArea,
  string? Building,
  string? AdditionalJsonInfo,
  double Price,
  DateTime Date,
  Status Status,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);