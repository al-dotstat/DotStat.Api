using DotStat.Api.Domain.Common.Enums;

namespace DotStat.Api.Contracts.Storage;

public record StorageResponse(
  int Id,
  string Title,
  StorageDeclarationResponse? Declaration,
  int BuildingId,
  int DeveloperId,
  string? Layout,
  string? DeveloperUnique,
  string? AdditionalJsonInfo,
  Status CurrentStatus,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);