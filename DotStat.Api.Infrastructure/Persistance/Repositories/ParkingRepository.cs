using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.BuildingAggregate.ValueObjects;
using DotStat.Api.Domain.ParkingAggregate;
using DotStat.Api.Domain.ParkingAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DotStat.Api.Infrastructure.Persistance.Repositories;

public class ParkingRepository(DotStatApiDbContext dbContext) : Repository<Parking>(dbContext), IParkingRepository
{
  public bool Exist(ParkingId id)
  {
    return _dbContext.Parkings.Any(p => p.Id == id);
  }

  public Task<bool> ExistAsync(ParkingId id)
  {
    return _dbContext.Parkings.AnyAsync(f => f.Id == id);
  }

  public Parking? GetById(ParkingId id)
  {
    return _dbContext.Parkings.Find(id);
  }

  public async Task<Parking?> GetByIdAsync(ParkingId id)
  {
    return await _dbContext.Parkings.FindAsync(id);
  }

  public ICollection<Parking> GetBuildingParkings(BuildingId buildingId)
  {
    return [.. _dbContext.Parkings.Where(p => p.BuildingId == buildingId)];
  }

  public async Task<ICollection<Parking>> GetBuildingParkingsAsync(BuildingId buildingId)
  {
    return await _dbContext.Parkings.Where(p => p.BuildingId == buildingId).ToListAsync();
  }
}
