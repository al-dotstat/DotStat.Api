using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.ComplexQueries;

public class AllComplexesQueryHandler(IComplexRepository complexRepository) : IRequestHandler<AllComplexesQuery, ErrorOr<ComplexesResult>>
{
  public async Task<ErrorOr<ComplexesResult>> Handle(AllComplexesQuery request, CancellationToken cancellationToken)
  {
    var complexes = await complexRepository.GetAllComplexesAsync();
    return new ComplexesResult(complexes);
  }
}
