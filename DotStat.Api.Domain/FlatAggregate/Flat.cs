using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.Common.Enums;
using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.FlatAggregate.Entities;
using DotStat.Api.Domain.FlatAggregate.ValueObjects;

namespace DotStat.Api.Domain.FlatAggregate;

public sealed class Flat : AggregateRoot<FlatId, int>
{
  private readonly List<FlatParsingInfo> _parsingInfos = [];

  public string Title { get; private set; }
  public FlatDeclaration? Declaration { get; private set; }
  public BuildingId BuildingId { get; private set; }
  public DeveloperId DeveloperId { get; private set; }
  public string? Layout { get; private set; }
  public bool? IsEuro { get; private set; }
  public string? DeveloperUnique { get; private set; }
  public string? AdditionalJsonInfo { get; private set; }
  public Status CurrentStatus { get; private set; }

  public IReadOnlyList<FlatParsingInfo> ParsingInfos => _parsingInfos.ToList().AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Flat(
    string title,
    FlatDeclaration declaration,
    BuildingId buildingId,
    DeveloperId developerId,
    string? layout,
    bool? isEuro,
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
    IsEuro = isEuro;
    DeveloperUnique = developerUnique;
    AdditionalJsonInfo = additionalJsonInfo;
    CurrentStatus = currentStatus;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Flat Create(
    string title,
    FlatDeclaration declaration,
    BuildingId buildingId,
    DeveloperId developerId,
    string? layout,
    bool? isEuro,
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
      isEuro,
      developerUnique,
      additionalJsonInfo,
      currentStatus,
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

  public void AddParsingInfo(FlatParsingInfo parsingInfo)
  {
    _parsingInfos.Add(parsingInfo);
    CurrentStatus = parsingInfo.Status;
    UpdatedDateTime = DateTime.UtcNow;
  }

  public void RemoveParsingInfo(FlatParsingInfo parsingInfo)
  {
    _parsingInfos.Remove(parsingInfo);
    var lastParsingInfo = _parsingInfos.MaxBy(pi => pi.Date);
    CurrentStatus = lastParsingInfo?.Status ?? Status.NoInfo;
    UpdatedDateTime = DateTime.UtcNow;
  }

#pragma warning disable CS8618
  private Flat()
  {
  }
#pragma warning restore CS8618
}