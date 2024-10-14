using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.SearchQueries;

public record ComplexesByFiltersQuery(
  IEnumerable<DeveloperId> DeveloperIds,
  IEnumerable<DistrictId> DistrictIds,
  string Search
) : IRequest<ErrorOr<ComplexesResult>>;