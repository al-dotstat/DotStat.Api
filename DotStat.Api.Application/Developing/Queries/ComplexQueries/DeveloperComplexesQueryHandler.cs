using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.ComplexQueries;

public class DeveloperComplexesQueryHandler(
  IComplexRepository complexRepository,
  IDeveloperRepository developerRepository
) : IRequestHandler<DeveloperComplexesQuery, ErrorOr<ComplexesResult>>
{
  public async Task<ErrorOr<ComplexesResult>> Handle(DeveloperComplexesQuery request, CancellationToken cancellationToken)
  {
    if (!await developerRepository.ExistAsync(request.Id))
      return Errors.Developer.UnknownDeveloper;

    var complexes = await complexRepository.GetDeveloperComplexesAsync(request.Id);
    return new ComplexesResult(complexes);
  }
}
