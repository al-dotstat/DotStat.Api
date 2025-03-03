using DotStat.Api.Domain.Common.Enums;

namespace DotStat.Api.Contracts.Parking;

public record ParkingParsingInfoResponse(
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