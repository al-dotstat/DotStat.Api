using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Contracts.Common;
using DotStat.Api.Contracts.Parse;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class ParseMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<ParseId, int>()
      .MapWith(src => src.Value);

    config.NewConfig<ParsingResult, ParseResponse>();

    config.NewConfig<ParsingsResult, CollectionResponse<ParseResponse>>()
      .Map(dest => dest.Items, src => src.Parsings);
  }
}
