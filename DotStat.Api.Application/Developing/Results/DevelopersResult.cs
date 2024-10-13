using DotStat.Api.Domain.DeveloperAggregate;

namespace DotStat.Api.Application.Developing.Results;

public record DevelopersResult(
  IEnumerable<Developer> Developers
);