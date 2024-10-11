using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ComplexAggregate.Entities;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;

namespace DotStat.Api.Domain.ComplexAggregate;

public sealed class Complex : AggregateRoot<ComplexId, int>
{
  private readonly List<ComplexDeveloper> _developers = [];
  private readonly List<ParseId> _parseIds = [];

  public string Name { get; private set; }
  public string NameRu { get; private set; }
  public string? Address { get; private set; }
  public string? Latitude { get; private set; }
  public string? Longitude { get; private set; }
  public double? Area { get; private set; }
  public DateTime? CompletionDate { get; private set; }
  public District District { get; private set; }

  public IReadOnlyList<ComplexDeveloper> Developers => _developers.ToList().AsReadOnly();
  public IReadOnlyList<ParseId> ParseIds => _parseIds.ToList().AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Complex(
    string name,
    string nameRu,
    string? address,
    string? latitude,
    string? longitude,
    double? area,
    DateTime? completionDate,
    District district,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    Name = name;
    NameRu = nameRu;
    Address = address;
    Latitude = latitude;
    Longitude = longitude;
    Area = area;
    CompletionDate = completionDate;
    District = district;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Complex Create(
    string name,
    string nameRu,
    string? address,
    string? latitude,
    string? longitude,
    double? area,
    DateTime? completionDate,
    District district
  )
  {
    return new(
      name,
      nameRu,
      address,
      latitude,
      longitude,
      area,
      completionDate,
      district,
      DateTime.UtcNow,
      DateTime.UtcNow
    );
  }

  public void SetDevelopers(IEnumerable<ComplexDeveloper> developers)
  {
    _developers.RemoveAll(id => true);
    _developers.AddRange(developers);
    UpdatedDateTime = DateTime.UtcNow;
  }

  public void AddParse(ParseId parseId)
  {
    _parseIds.Add(parseId);
    UpdatedDateTime = DateTime.UtcNow;
  }

  public void RemoveParse(ParseId parseId)
  {
    _parseIds.Remove(parseId);
    UpdatedDateTime = DateTime.UtcNow;
  }

#pragma warning disable CS8618
  private Complex()
  {
  }
#pragma warning restore CS8618
}