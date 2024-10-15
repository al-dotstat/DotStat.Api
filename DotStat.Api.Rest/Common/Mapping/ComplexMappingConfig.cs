using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Contracts.Common;
using DotStat.Api.Contracts.Complex;
using DotStat.Api.Domain.ComplexAggregate;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class ComplexMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<ComplexId, int>()
      .MapWith(src => src.Value);

    config.NewConfig<Complex, ComplexResponse>();

    config.NewConfig<ComplexResult, ComplexResponse>()
      .Map(dest => dest, src => src.Complex);

    config.NewConfig<ComplexesResult, CollectionResponse<ComplexResponse>>()
      .Map(dest => dest.Items, src => src.Complexes);
  }
}