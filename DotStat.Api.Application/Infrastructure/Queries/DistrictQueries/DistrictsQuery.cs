using DotStat.Api.Application.Infrastructure.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Infrastructure.Queries.DistrictQueries;

public record DistrictsQuery() : IRequest<ErrorOr<DistrictsResult>>;