using DotStat.Api.Domain.DistrictAggregate;

namespace DotStat.Api.Application.Developing.Results;

public record DistrictsResult(IEnumerable<District> Districts);