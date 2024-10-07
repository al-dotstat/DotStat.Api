namespace DotStat.Api.Contracts.Order;

public record OrderItemResponse(
  int ComplexId,
  bool IncludeFlats,
  bool IncludeParkings,
  bool IncludeStorages,
  bool IncludeCommercials
);