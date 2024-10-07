namespace DotStat.Api.Contracts.Parking;

public record ParkingResponse(
  int Id,
  string Title,
  ParkingDeclarationResponse? Declaration,
  int BuildingId,
  int DeveloperId,
  string? Layout,
  string? DeveloperUnique,
  string? AdditionalJsonInfo,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);