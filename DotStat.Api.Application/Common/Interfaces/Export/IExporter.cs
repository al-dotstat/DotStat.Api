using DotStat.Api.Domain.CommercialAggregate;
using DotStat.Api.Domain.FlatAggregate;
using DotStat.Api.Domain.ParkingAggregate;
using DotStat.Api.Domain.StorageAggregate;

namespace DotStat.Api.Application.Common.Interfaces.Export;

public interface IExporter
{
  byte[] Export(string complex, IEnumerable<Flat> flats, IEnumerable<Storage> storages, IEnumerable<Parking> parkings, IEnumerable<Commercial> commercials);
  void ExportToFile(string filePath, string complex, IEnumerable<Flat> flats, IEnumerable<Storage> storages, IEnumerable<Parking> parkings, IEnumerable<Commercial> commercials);
  // byte[] ZipFiles(IEnumerable<(byte[] Body, string Name)> files);
  void ExportToZip(string filePath, IEnumerable<(byte[] Body, string Name)> files);
}