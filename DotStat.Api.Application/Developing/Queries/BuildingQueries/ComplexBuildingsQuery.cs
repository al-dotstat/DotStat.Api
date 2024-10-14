using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.BuildingQueries;

public record ComplexBuildingsQuery(
  ComplexId Id
) : IRequest<ErrorOr<BuildingsResult>>;