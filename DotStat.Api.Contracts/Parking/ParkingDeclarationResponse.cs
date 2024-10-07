namespace DotStat.Api.Contracts.Parking;

public record ParkingDeclarationResponse(
  int Id,
  string Number,
  string Floor,
  double Area,
  string Entrance,
  string Unique,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);