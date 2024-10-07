using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;

namespace DotStat.Api.Domain.ParseAggregate;

public sealed class Parse : AggregateRoot<ParseId, int>
{
  public DateTime Date { get; private set; }
  public ComplexId ComplexId { get; private set; }
  public bool AreFlatsParsed { get; private set; }
  public bool AreParkingsParsed { get; private set; }
  public bool AreStoragesParsed { get; private set; }
  public bool AreCommercialsParsed { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Parse(
    DateTime date,
    ComplexId complexId,
    bool areFlatsParsed,
    bool areParkingsParsed,
    bool areStoragesParsed,
    bool areCommercialsParsed,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    Date = date;
    ComplexId = complexId;
    AreFlatsParsed = areFlatsParsed;
    AreParkingsParsed = areParkingsParsed;
    AreStoragesParsed = areStoragesParsed;
    AreCommercialsParsed = areCommercialsParsed;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Parse Create(
    DateTime date,
    ComplexId complexId,
    bool areFlatsParsed,
    bool areParkingsParsed,
    bool areStoragesParsed,
    bool areCommercialsParsed
  )
  {
    return new(
      date,
      complexId,
      areFlatsParsed,
      areParkingsParsed,
      areStoragesParsed,
      areCommercialsParsed,
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

#pragma warning disable CS8618
  private Parse()
  {
  }
#pragma warning restore CS8618
}