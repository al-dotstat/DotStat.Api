using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.FlatAggregate.ValueObjects;

namespace DotStat.Api.Domain.FlatAggregate.Entities;

public sealed class FlatDeclaration : Entity<FlatDeclarationId>
{
  public string Number { get; private set; }
  public string Roominess { get; private set; }
  public string Floor { get; private set; }
  public double Area { get; private set; }
  public double LivingArea { get; private set; }
  public double CeilingHeight { get; private set; }
  public string Entrance { get; private set; }
  public string Unique { get; private set; }

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private FlatDeclaration(
    string number,
    string roominess,
    string floor,
    double area,
    double livingArea,
    double ceilingHeight,
    string entrance,
    string unique,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    Number = number;
    Roominess = roominess;
    Floor = floor;
    Area = area;
    LivingArea = livingArea;
    CeilingHeight = ceilingHeight;
    Entrance = entrance;
    Unique = unique;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static FlatDeclaration Create(
    string number,
    string roominess,
    string floor,
    double area,
    double livingArea,
    double ceilingHeight,
    string entrance,
    string unique
  )
  {
    return new(
      number,
      roominess,
      floor,
      area,
      livingArea,
      ceilingHeight,
      entrance,
      unique,
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

#pragma warning disable CS8618
  private FlatDeclaration()
  {
  }
#pragma warning restore CS8618
}