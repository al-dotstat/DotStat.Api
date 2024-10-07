using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.DeveloperAggregate.ValueObjects;
using DotStat.Api.Domain.ParkingAggregate.Entities;
using DotStat.Api.Domain.ParkingAggregate.ValueObjects;

namespace DotStat.Api.Domain.ParkingAggregate;

public sealed class Parking : AggregateRoot<ParkingId, int>
{
  private readonly List<ParkingParsingInfo> _parsingInfos = [];

  public string Title { get; private set; }
  public ParkingDeclaration? Declaration { get; private set; }
  public BuildingId BuildingId { get; private set; }
  public DeveloperId DeveloperId { get; private set; }
  public string? Layout { get; private set; }
  public string? DeveloperUnique { get; private set; }
  public string? AdditionalJsonInfo { get; private set; }

  public IReadOnlyList<ParkingParsingInfo> ParsingInfos => _parsingInfos.ToList().AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Parking(
    string title,
    ParkingDeclaration declaration,
    BuildingId buildingId,
    DeveloperId developerId,
    string? layout,
    string? developerUnique,
    string? additionalJsonInfo,
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
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Parking Create(
    string title,
    ParkingDeclaration declaration,
    BuildingId buildingId,
    DeveloperId developerId,
    string? layout,
    string? developerUnique,
    string? additionalJsonInfo
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
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

  public void AddParsingInfo(ParkingParsingInfo parsingInfo)
  {
    _parsingInfos.Add(parsingInfo);
    UpdatedDateTime = DateTime.UtcNow;
  }

  public void RemoveParsingInfo(ParkingParsingInfo parsingInfo)
  {
    _parsingInfos.Remove(parsingInfo);
    UpdatedDateTime = DateTime.UtcNow;
  }

#pragma warning disable CS8618
  private Parking()
  {
  }
#pragma warning restore CS8618
}