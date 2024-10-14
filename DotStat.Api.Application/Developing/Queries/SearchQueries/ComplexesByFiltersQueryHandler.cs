using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.SearchQueries;

public class ComplexesByFiltersQueryHandler(IComplexRepository complexRepository) : IRequestHandler<ComplexesByFiltersQuery, ErrorOr<ComplexesResult>>
{
  public async Task<ErrorOr<ComplexesResult>> Handle(ComplexesByFiltersQuery request, CancellationToken cancellationToken)
  {
    var res = await complexRepository.SearchByFiltersAsync(
      request.DeveloperIds,
      request.DistrictIds,
      request.Search);

    return new ComplexesResult(res);
  }
}
