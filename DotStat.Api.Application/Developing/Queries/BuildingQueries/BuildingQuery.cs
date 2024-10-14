using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.BuildingQueries;

public record BuildingQuery(BuildingId Id) : IRequest<ErrorOr<BuildingResult>>;