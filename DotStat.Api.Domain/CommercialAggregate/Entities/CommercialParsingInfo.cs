using DotStat.Api.Domain.CommercialAggregate.ValueObjects;
using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;

namespace DotStat.Api.Domain.CommercialAggregate.Entities;

public class CommercialParsingInfo : Entity<CommercialParsingInfoId>
{
  public ParseId ParseId { get; private set; }
  public string? Number { get; private set; }
  public string? Floor { get; private set; }
  public double? Area { get; private set; }
  public string? Building { get; private set; }
  public string? AdditionalJsonInfo { get; private set; }
  public double Price { get; private set; }
  public DateTime Date { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private CommercialParsingInfo(
    ParseId parseId,
    string? number,
    string? floor,
    double? area,
    string? building,
    string? additionalJsonInfo,
    double price,
    DateTime date,
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
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static CommercialParsingInfo Create(
    ParseId parseId,
    string? number,
    string? floor,
    double? area,
    string? building,
    string? additionalJsonInfo,
    double price,
    DateTime date
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
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

#pragma warning disable CS8618
  private CommercialParsingInfo()
  {
  }
#pragma warning restore CS8618
}