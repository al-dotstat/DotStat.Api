using DotStat.Api.Contracts.Complex;
using DotStat.Api.Contracts.Developer;

namespace DotStat.Api.Contracts.Common;

public record SearchResponse(
  ComplexResponse[] Complexes,
  DeveloperResponse[] Developers
);