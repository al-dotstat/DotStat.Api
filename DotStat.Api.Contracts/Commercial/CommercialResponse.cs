using DotStat.Api.Domain.Common.Enums;

namespace DotStat.Api.Contracts.Commercial;

public record CommercialResponse(
  int Id,
  string Title,
  CommercialDeclarationResponse? Declaration,
  int BuildingId,
  int DeveloperId,
  string? Layout,
  string? DeveloperUnique,
  string? AdditionalJsonInfo,
  Status CurrentStatus,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);