using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.DistrictQueries;

public record DistrictQuery(
  DistrictId DistrictId
) : IRequest<ErrorOr<DistrictResult>>;