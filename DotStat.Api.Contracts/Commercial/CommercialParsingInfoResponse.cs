using DotStat.Api.Domain.Common.Enums;

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
  Status Status,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);