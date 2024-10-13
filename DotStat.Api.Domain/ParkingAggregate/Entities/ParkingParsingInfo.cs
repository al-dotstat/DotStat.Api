using DotStat.Api.Domain.Common.Enums;
using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ParkingAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;

namespace DotStat.Api.Domain.ParkingAggregate.Entities;

public class ParkingParsingInfo : Entity<ParkingParsingInfoId>
{
  public ParseId ParseId { get; private set; }
  public string? Number { get; private set; }
  public string? Floor { get; private set; }
  public double? Area { get; private set; }
  public string? Building { get; private set; }
  public string? AdditionalJsonInfo { get; private set; }
  public double Price { get; private set; }
  public DateTime Date { get; private set; }
  public Status Status { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private ParkingParsingInfo(
    ParseId parseId,
    string? number,
    string? floor,
    double? area,
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
    Floor = floor;
    Area = area;
    Building = building;
    AdditionalJsonInfo = additionalJsonInfo;
    Price = price;
    Date = date;
    Status = status;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static ParkingParsingInfo Create(
    ParseId parseId,
    string? number,
    string? floor,
    double? area,
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
      floor,
      area,
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
  private ParkingParsingInfo()
  {
  }
#pragma warning restore CS8618
}