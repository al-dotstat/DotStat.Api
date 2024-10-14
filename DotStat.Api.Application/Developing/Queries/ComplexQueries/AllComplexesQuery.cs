using DotStat.Api.Application.Developing.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.ComplexQueries;

public record AllComplexesQuery() : IRequest<ErrorOr<ComplexesResult>>;