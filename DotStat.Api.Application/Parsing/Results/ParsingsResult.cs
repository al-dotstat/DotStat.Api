namespace DotStat.Api.Application.Parsing.Results;

public record ParsingsResult(
  IEnumerable<ParsingResult> Parsings
);