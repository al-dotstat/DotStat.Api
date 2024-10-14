using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.BuildingQueries;

public class BuildingQueryHandler(IBuildingRepository buildingRepository) : IRequestHandler<BuildingQuery, ErrorOr<BuildingResult>>
{
  public async Task<ErrorOr<BuildingResult>> Handle(BuildingQuery request, CancellationToken cancellationToken)
  {
    if (await buildingRepository.GetByIdAsync(request.Id) is not Building building)
      return Errors.Building.UnknownBuilding;

    return new BuildingResult(building);
  }
}
