using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Contracts.Common;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class SearchMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<SearchResult, SearchResponse>()
      .Map(dest => dest.Complexes, src => src.Complexes)
      .Map(dest => dest.Developers, src => src.Developers);
  }
}
