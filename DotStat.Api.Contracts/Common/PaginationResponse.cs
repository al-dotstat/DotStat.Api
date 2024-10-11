namespace DotStat.Api.Contracts.Common;

public record PaginationResponse<T>(
  int TotalCount,
  int PerPageCount,
  T[] Items
);