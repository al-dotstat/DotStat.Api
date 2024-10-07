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
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);