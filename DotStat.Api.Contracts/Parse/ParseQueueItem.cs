namespace DotStat.Api.Contracts.Parse;

public record ParseQueueItem(
  int QueueItemId,
  int ComplexId,
  DateTime CreatedDateTime
);