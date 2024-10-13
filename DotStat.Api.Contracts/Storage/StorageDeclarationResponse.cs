namespace DotStat.Api.Contracts.Storage;

public record StorageDeclarationResponse(
  int Id,
  string Number,
  string Floor,
  double Area,
  string Entrance,
  string Unique,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);