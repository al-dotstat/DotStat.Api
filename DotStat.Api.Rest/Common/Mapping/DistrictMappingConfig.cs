using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Contracts.District;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class DistrictMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<DistrictId, int>()
      .MapWith(src => src.Value);

    config.NewConfig<DistrictResult, DistrictResponse>()
      .Map(dest => dest, src => src.District);

    config.NewConfig<DistrictsResult, DistrictResponse[]>()
      .Map(dest => dest, src => src.Districts);
  }
}
