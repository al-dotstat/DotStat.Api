using DotStat.Api.Application.Infrastructure.Results;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Infrastructure.Queries.DistrictQueries;

public record DistrictQuery(
  DistrictId DistrictId
) : IRequest<ErrorOr<DistrictResult>>;