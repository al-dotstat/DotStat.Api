using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.DeveloperQuery;

public record DeveloperQuery(
  DeveloperId Id
) : IRequest<ErrorOr<DeveloperResult>>;