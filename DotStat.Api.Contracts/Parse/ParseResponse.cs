namespace DotStat.Api.Contracts.Parse;

public record ParseResponse(
  int Id,
  DateTime Date,
  int ComplexId,
  bool AreFlatsParsed,
  bool AreParkingsParsed,
  bool AreStoragesParsed,
  bool AreCommercialsParsed,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);