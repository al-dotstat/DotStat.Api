using DotStat.Api.Domain.Common.Enums;
using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.FlatAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;

namespace DotStat.Api.Domain.FlatAggregate.Entities;

public class FlatParsingInfo : Entity<FlatParsingInfoId>
{
  public ParseId ParseId { get; private set; }
  public string? Number { get; private set; }
  public string? Roominess { get; private set; }
  public string? Floor { get; private set; }
  public double? Area { get; private set; }
  public double? LivingArea { get; private set; }
  public string? Building { get; private set; }
  public string? AdditionalJsonInfo { get; private set; }
  public double Price { get; private set; }
  public DateTime Date { get; private set; }
  public Status Status { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private FlatParsingInfo(
    ParseId parseId,
    string? number,
    string? roominess,
    string? floor,
    double? area,
    double? livingArea,
    string? building,
    string? additionalJsonInfo,
    double price,
    DateTime date,
    Status status,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    ParseId = parseId;
    Number = number;
    Roominess = roominess;
    Floor = floor;
    Area = area;
    LivingArea = livingArea;
    Building = building;
    AdditionalJsonInfo = additionalJsonInfo;
    Price = price;
    Date = date;
    Status = status;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static FlatParsingInfo Create(
    ParseId parseId,
    string? number,
    string? roominess,
    string? floor,
    double? area,
    double? livingArea,
    string? building,
    string? additionalJsonInfo,
    double price,
    DateTime date,
    Status status
  )
  {
    return new(
      parseId,
      number,
      roominess,
      floor,
      area,
      livingArea,
      building,
      additionalJsonInfo,
      price,
      date,
      status,
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

#pragma warning disable CS8618
  private FlatParsingInfo()
  {
  }
#pragma warning restore CS8618
}