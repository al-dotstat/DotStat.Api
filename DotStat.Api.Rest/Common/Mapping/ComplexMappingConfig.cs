using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Contracts.Complex;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class ComplexMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<ComplexId, int>()
      .MapWith(src => src.Value);

    config.NewConfig<ComplexResult, ComplexResponse>()
      .Map(dest => dest, src => src.Complex);

    config.NewConfig<ComplexesResult, ComplexResponse[]>()
      .Map(dest => dest, src => src.Complexes);
  }
}