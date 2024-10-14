using DotStat.Api.Application.Developing.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.SearchQueries;

public record SearchQuery(
  string Search
) : IRequest<ErrorOr<SearchResult>>;