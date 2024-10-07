using DotStat.Api.Domain.CommercialAggregate.ValueObjects;
using DotStat.Api.Domain.Common.Models;

namespace DotStat.Api.Domain.CommercialAggregate.Entities;

public sealed class CommercialDeclaration : Entity<CommercialDeclarationId>
{
  public string Number { get; private set; }
  public string Floor { get; private set; }
  public double Area { get; private set; }
  public string Entrance { get; private set; }
  public string Unique { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private CommercialDeclaration(
    string number,
    string floor,
    double area,
    string entrance,
    string unique,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    Number = number;
    Floor = floor;
    Area = area;
    Entrance = entrance;
    Unique = unique;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static CommercialDeclaration Create(
    string number,
    string floor,
    double area,
    string entrance,
    string unique
  )
  {
    return new(
      number,
      floor,
      area,
      entrance,
      unique,
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

#pragma warning disable CS8618
  private CommercialDeclaration()
  {
  }
#pragma warning restore CS8618
}