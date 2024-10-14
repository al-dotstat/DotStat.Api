using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.SearchQueries;

public class SearchQueryHandler(IComplexRepository complexRepository, IDeveloperRepository developerRepository) : IRequestHandler<SearchQuery, ErrorOr<SearchResult>>
{
  public async Task<ErrorOr<SearchResult>> Handle(SearchQuery request, CancellationToken cancellationToken)
  {
    var complexes = await complexRepository.SearchAsync(request.Search);
    var developers = await developerRepository.SearchAsync(request.Search);

    return new SearchResult(complexes, developers);
  }
}
