using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Infrastructure.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Infrastructure.Queries.DistrictQueries;

public class DistrictsQueryHandler(IDistrictRepository districtRepository) : IRequestHandler<DistrictsQuery, ErrorOr<DistrictsResult>>
{
  public async Task<ErrorOr<DistrictsResult>> Handle(DistrictsQuery request, CancellationToken cancellationToken)
  {
    var districts = await districtRepository.GetAllAsync();

    return new DistrictsResult(districts);
  }
}
