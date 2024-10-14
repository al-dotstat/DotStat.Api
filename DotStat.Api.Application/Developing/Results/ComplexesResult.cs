using DotStat.Api.Domain.ComplexAggregate;

namespace DotStat.Api.Application.Developing.Results;

public record ComplexesResult(
  IEnumerable<Complex> Complexes
);