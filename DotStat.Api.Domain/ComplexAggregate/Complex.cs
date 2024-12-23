using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.DistrictAggregate.ValueObjects;

namespace DotStat.Api.Domain.ComplexAggregate;

public sealed class Complex : AggregateRoot<ComplexId, int>
{
  private readonly List<ComplexDeveloper> _developers = [];

  public string Name { get; private set; }
  public string NameRu { get; private set; }
  public string? Description { get; private set; }
  public string? Address { get; private set; }
  public string? Latitude { get; private set; }
  public string? Longitude { get; private set; }
  public double? Area { get; private set; }
  public string? ImageFilePath { get; private set; }
  public DateTime? CompletionDate { get; private set; }
  public DistrictId DistrictId { get; private set; }

  public IReadOnlyList<ComplexDeveloper> Developers => _developers.ToList().AsReadOnly();

  public DateTime CreatedDateTime { get; private set; }
  public DateTime UpdatedDateTime { get; private set; }

  private Complex(
    string name,
    string nameRu,
    string? description,
    string? address,
    string? latitude,
    string? longitude,
    double? area,
    string? imageFilePath,
    DateTime? completionDate,
    DistrictId districtId,
    DateTime createdDateTime,
    DateTime updatedDateTime
  )
  {
    Name = name;
    NameRu = nameRu;
    Description = description;
    Address = address;
    Latitude = latitude;
    Longitude = longitude;
    Area = area;
    ImageFilePath = imageFilePath;
    CompletionDate = completionDate;
    DistrictId = districtId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public static Complex Create(
    string name,
    string nameRu,
    string? description,
    string? address,
    string? latitude,
    string? longitude,
    double? area,
    string? imageFilePath,
    DateTime? completionDate,
    DistrictId districtId
  )
  {
    return new(
      name,
      nameRu,
      description,
      address,
      latitude,
      longitude,
      area,
      imageFilePath,
      completionDate,
      districtId,
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

#pragma warning disable CS8618
  private Complex()
  {
  }
#pragma warning restore CS8618
}