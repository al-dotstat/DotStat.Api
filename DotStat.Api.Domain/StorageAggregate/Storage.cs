using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.Common.Enums;
using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.StorageAggregate.Entities;
using DotStat.Api.Domain.StorageAggregate.ValueObjects;

namespace DotStat.Api.Domain.StorageAggregate;

public sealed class Storage : AggregateRoot<StorageId, int>
{
  private readonly List<StorageParsingInfo> _parsingInfos = [];

  public string Title { get; private set; }
  public StorageDeclaration? Declaration { get; private set; }
  public BuildingId BuildingId { get; private set; }
  public DeveloperId DeveloperId { get; private set; }
  public string? Layout { get; private set; }
  public string? DeveloperUnique { get; private set; }
  public string? AdditionalJsonInfo { get; private set; }
  public Status CurrentStatus { get; private set; }

  public IReadOnlyList<StorageParsingInfo> ParsingInfos => _parsingInfos.ToList().AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Storage(
    string title,
    StorageDeclaration declaration,
    BuildingId buildingId,
    DeveloperId developerId,
    string? layout,
    string? developerUnique,
    string? additionalJsonInfo,
    Status currentStatus,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    Title = title;
    Declaration = declaration;
    BuildingId = buildingId;
    DeveloperId = developerId;
    Layout = layout;
    DeveloperUnique = developerUnique;
    AdditionalJsonInfo = additionalJsonInfo;
    CurrentStatus = currentStatus;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Storage Create(
    string title,
    StorageDeclaration declaration,
    BuildingId buildingId,
    DeveloperId developerId,
    string? layout,
    string? developerUnique,
    string? additionalJsonInfo,
    Status currentStatus
  )
  {
    return new(
      title,
      declaration,
      buildingId,
      developerId,
      layout,
      developerUnique,
      additionalJsonInfo,
      currentStatus,
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

  public void AddParsingInfo(StorageParsingInfo parsingInfo)
  {
    _parsingInfos.Add(parsingInfo);
    CurrentStatus = parsingInfo.Status;
    UpdatedDateTime = DateTime.UtcNow;
  }

  public void RemoveParsingInfo(StorageParsingInfo parsingInfo)
  {
    _parsingInfos.Remove(parsingInfo);
    var lastParsingInfo = _parsingInfos.MaxBy(pi => pi.Date);
    CurrentStatus = lastParsingInfo?.Status ?? Status.NoInfo;
    UpdatedDateTime = DateTime.UtcNow;
  }

#pragma warning disable CS8618
  private Storage()
  {
  }
#pragma warning restore CS8618
}