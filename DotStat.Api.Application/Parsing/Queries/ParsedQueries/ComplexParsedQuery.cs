using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Queries.ParsedQueries;

public record ComplexParsedQuery(
  ComplexId ComplexId
) : IRequest<ErrorOr<ParsingsResult>>;