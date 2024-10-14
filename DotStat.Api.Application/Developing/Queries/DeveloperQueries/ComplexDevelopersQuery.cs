using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.DeveloperQueries;

public record ComplexDevelopersQuery(ComplexId Id) : IRequest<ErrorOr<DevelopersResult>>;