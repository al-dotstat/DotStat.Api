namespace DotStat.Api.Application.Parsing.Results;

public record TableResult(
  string[,]? Flats,
  string[,]? Parkings,
  string[,]? Storages,
  string[,]? Commercials
);