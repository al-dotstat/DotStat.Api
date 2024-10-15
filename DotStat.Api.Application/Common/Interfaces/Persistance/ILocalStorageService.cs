namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface ILocalStorageService
{
  Stream GetFileStream(string name);
  string GetStoragePath();
}