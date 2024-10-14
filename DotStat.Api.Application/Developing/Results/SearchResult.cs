using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.DeveloperAggregate;

namespace DotStat.Api.Application.Developing.Results;

public record SearchResult(
  IEnumerable<Complex> Complexes,
  IEnumerable<Developer> Developers
);