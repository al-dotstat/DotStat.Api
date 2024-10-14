namespace DotStat.Api.Contracts.Order;

public record OrderRequest(
  OrderItemRequest[] OrderItems
);

public record OrderItemRequest(
  int ComplexId,
  bool IncludeFlats,
  bool IncludeParkings,
  bool IncludeStorages,
  bool IncludeCommercials
);