using DotStat.Api.Domain.BuildingAggregate;

namespace DotStat.Api.Application.Developing.Results;

public record BuildingsResult(IEnumerable<Building> Buildings);