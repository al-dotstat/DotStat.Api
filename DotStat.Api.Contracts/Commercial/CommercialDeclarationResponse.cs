namespace DotStat.Api.Contracts.Commercial;

public record CommercialDeclarationResponse(
  int Id,
  string Number,
  string Floor,
  double Area,
  string Entrance,
  string Unique,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);