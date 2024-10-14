using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.ComplexQueries;

public record ComplexQuery(ComplexId Id) : IRequest<ErrorOr<ComplexResult>>;