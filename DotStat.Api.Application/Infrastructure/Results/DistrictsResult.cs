using DotStat.Api.Domain.DistrictAggregate;

namespace DotStat.Api.Application.Infrastructure.Results;

public record DistrictsResult(IEnumerable<District> Districts);