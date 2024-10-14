using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.DeveloperQueries;

public record DeveloperQuery(
  DeveloperId Id
) : IRequest<ErrorOr<DeveloperResult>>;