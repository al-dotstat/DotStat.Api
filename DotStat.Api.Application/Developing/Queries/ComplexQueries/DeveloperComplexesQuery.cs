using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.ComplexQueries;

public record DeveloperComplexesQuery(
  DeveloperId Id
) : IRequest<ErrorOr<ComplexesResult>>;