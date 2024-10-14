using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.BuildingQueries;

public class ComplexBuildingsQueryHandler(IBuildingRepository buildingRepository, IComplexRepository complexRepository) : IRequestHandler<ComplexBuildingsQuery, ErrorOr<BuildingsResult>>
{
  public async Task<ErrorOr<BuildingsResult>> Handle(ComplexBuildingsQuery request, CancellationToken cancellationToken)
  {
    if (!await complexRepository.ExistAsync(request.Id))
      return Errors.Complex.UnknownComplex;

    var buildings = await buildingRepository.GetComplexBuildingsAsync(request.Id);
    return new BuildingsResult(buildings);
  }
}
