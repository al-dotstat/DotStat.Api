using DotStat.Api.Application.Developing.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.DistrictQueries;

public record DistrictsQuery() : IRequest<ErrorOr<DistrictsResult>>;