using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Infrastructure.Results;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.DistrictAggregate;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Infrastructure.Queries.DistrictQueries;

public class DistrictQueryHandler(IDistrictRepository districtRepository) : IRequestHandler<DistrictQuery, ErrorOr<DistrictResult>>
{
  public async Task<ErrorOr<DistrictResult>> Handle(DistrictQuery request, CancellationToken cancellationToken)
  {
    if (await districtRepository.GetByIdAsync(request.DistrictId) is not District district)
      return Errors.District.UnknownDistrict;

    return new DistrictResult(district);
  }
}
