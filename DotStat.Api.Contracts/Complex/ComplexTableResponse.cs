namespace DotStat.Api.Contracts.Complex;

public record ComplexTableResponse(
  string[,]? Flats,
  string[,]? Parkings,
  string[,]? Storages,
  string[,]? Commercials
);