namespace DotStat.Api.Contracts.Common;

public record CollectionResponse<T>(ICollection<T> Items);