using DotStat.Api.Application.Common.Interfaces.Persistance;

namespace DotStat.Api.Infrastructure.Persistance;

public class LocalStorageService : ILocalStorageService
{
  public LocalStorageService()
  {
    var storagePath = GetStoragePath();
    if (!Directory.Exists(storagePath))
      Directory.CreateDirectory(storagePath);
  }

  public Stream GetFileStream(string name)
  {
    return new FileStream(Path.Combine(GetStoragePath(), name), FileMode.Open);
  }

  public string GetStoragePath()
  {
    return Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");
  }
}
