using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.DeveloperQueries;

public class ComplexDevelopersQueryHandler(IComplexRepository complexRepository, IDeveloperRepository developerRepository) : IRequestHandler<ComplexDevelopersQuery, ErrorOr<DevelopersResult>>
{
  public async Task<ErrorOr<DevelopersResult>> Handle(ComplexDevelopersQuery request, CancellationToken cancellationToken)
  {
    if (!await complexRepository.ExistAsync(request.Id))
      return Errors.Complex.UnknownComplex;

    var developers = await developerRepository.GetComplexDevelopersAsync(request.Id);
    return new DevelopersResult(developers);
  }
}
