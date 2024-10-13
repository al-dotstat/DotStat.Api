using DotStat.Api.Domain.Common.Enums;

namespace DotStat.Api.Contracts.Flat;

public record FlatResponse(
  int Id,
  string Title,
  int BuildingId,
  int DeveloperId,
  string? Layout,
  bool? IsEuro,
  string? DeveloperUnique,
  string? AdditionalJsonInfo,
  FlatDeclarationResponse? Declaration,
  Status CurrentStatus,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);