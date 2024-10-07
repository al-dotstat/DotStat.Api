namespace DotStat.Api.Contracts.Flat;

public record FlatDeclarationResponse(
  int Id,
  string Number,
  string Roominess,
  string Floor,
  double Area,
  double LivingArea,
  double CeilingHeight,
  string Entrance,
  string Unique,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);