using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.CommercialAggregate.Entities;
using DotStat.Api.Domain.CommercialAggregate.ValueObjects;
using DotStat.Api.Domain.Common.Enums;
using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;

namespace DotStat.Api.Domain.CommercialAggregate;

public sealed class Commercial : AggregateRoot<CommercialId, int>
{
  private readonly List<CommercialParsingInfo> _parsingInfos = [];

  public string Title { get; private set; }
  public CommercialDeclaration? Declaration { get; private set; }
  public BuildingId BuildingId { get; private set; }
  public DeveloperId DeveloperId { get; private set; }
  public string? Layout { get; private set; }
  public string? DeveloperUnique { get; private set; }
  public string? AdditionalJsonInfo { get; private set; }
  public Status CurrentStatus { get; private set; }

  public IReadOnlyList<CommercialParsingInfo> ParsingInfos => _parsingInfos.ToList().AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Commercial(
    string title,
    CommercialDeclaration declaration,
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

  public static Commercial Create(
    string title,
    CommercialDeclaration declaration,
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

  public void AddParsingInfo(CommercialParsingInfo parsingInfo)
  {
    _parsingInfos.Add(parsingInfo);
    CurrentStatus = parsingInfo.Status;
    UpdatedDateTime = DateTime.UtcNow;
  }

  public void RemoveParsingInfo(CommercialParsingInfo parsingInfo)
  {
    _parsingInfos.Remove(parsingInfo);
    var lastParsingInfo = _parsingInfos.MaxBy(pi => pi.Date);
    CurrentStatus = lastParsingInfo?.Status ?? Status.NoInfo;
    UpdatedDateTime = DateTime.UtcNow;
  }

#pragma warning disable CS8618
  private Commercial()
  {
  }
#pragma warning restore CS8618
}