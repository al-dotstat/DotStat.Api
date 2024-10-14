using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.ComplexQueries;

public record DistrictComplexesQuery(DistrictId Id) : IRequest<ErrorOr<ComplexesResult>>;