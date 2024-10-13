using DotStat.Api.Domain.Common.Enums;

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
  Status CurrentStatus,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);