using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Contracts.Building;
using DotStat.Api.Domain.BuildingAggregate;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class BuildingMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<BuildingId, int>()
      .MapWith(src => src.Value);

    config.NewConfig<Building, BuildingResponse>();

    config.NewConfig<BuildingResult, BuildingResponse>()
      .Map(dest => dest, src => src.Building);

    config.NewConfig<BuildingsResult, BuildingResponse[]>()
      .Map(dest => dest, src => src.Buildings);
  }
}
