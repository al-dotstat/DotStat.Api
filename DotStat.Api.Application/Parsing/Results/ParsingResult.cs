using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;

namespace DotStat.Api.Application.Parsing.Results;

public record ParsingResult(
  ParseId Id,
  DateTime Date,
  ComplexId ComplexId,
  bool AreFlatsParsed,
  bool AreParkingsParsed,
  bool AreStoragesParsed,
  bool AreCommercialsParsed,
  DateTime CreatedDateTime,
  DateTime UpdatedDateTime
);