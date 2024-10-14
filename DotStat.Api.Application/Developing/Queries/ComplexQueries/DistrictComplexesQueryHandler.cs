using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.ComplexQueries;

public class DistrictComplexesQueryHandler(IDistrictRepository districtRepository, IComplexRepository complexRepository) : IRequestHandler<DistrictComplexesQuery, ErrorOr<ComplexesResult>>
{
  public async Task<ErrorOr<ComplexesResult>> Handle(DistrictComplexesQuery request, CancellationToken cancellationToken)
  {
    if (!await districtRepository.ExistAsync(request.Id))
      return Errors.District.UnknownDistrict;

    var complexes = await complexRepository.GetDistrictComplexesAsync(request.Id);
    return new ComplexesResult(complexes);
  }
}
