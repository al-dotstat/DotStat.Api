using DotStat.Api.Application.Infrastructure.Results;
using DotStat.Api.Contracts.Common;
using DotStat.Api.Contracts.District;
using DotStat.Api.Domain.DistrictAggregate;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class DistrictMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<DistrictId, int>()
      .MapWith(src => src.Value);

    config.NewConfig<District, DistrictResponse>();

    config.NewConfig<DistrictResult, DistrictResponse>()
      .Map(dest => dest, src => src.District);

    config.NewConfig<DistrictsResult, CollectionResponse<DistrictResponse>>()
      .Map(dest => dest.Items, src => src.Districts);
  }
}
