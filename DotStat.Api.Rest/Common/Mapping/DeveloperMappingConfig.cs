using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Contracts.Developer;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class DeveloperMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<DeveloperId, int>()
      .MapWith(src => src.Value);

    config.NewConfig<DeveloperResult, DeveloperResponse>()
      .Map(dest => dest, src => src.Developer);

    config.NewConfig<DevelopersResult, DeveloperResponse[]>()
      .Map(dest => dest, src => src.Developers);
  }
}
