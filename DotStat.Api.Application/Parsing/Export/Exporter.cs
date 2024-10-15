using System.IO.Compression;
using DotStat.Api.Application.Common.Interfaces.Export;
using DotStat.Api.Domain.CommercialAggregate;
using DotStat.Api.Domain.FlatAggregate;
using DotStat.Api.Domain.ParkingAggregate;
using DotStat.Api.Domain.StorageAggregate;

namespace DotStat.Api.Application.Parsing.Export;

public abstract class Exporter : IExporter
{
  public abstract byte[] Export(string complex, IEnumerable<Flat> flats, IEnumerable<Storage> storages, IEnumerable<Parking> parkings, IEnumerable<Commercial> commercials);

  public virtual void ExportToFile(string filePath, string complex, IEnumerable<Flat> flats, IEnumerable<Storage> storages, IEnumerable<Parking> parkings, IEnumerable<Commercial> commercials)
  {
    var fileBytes = Export(complex, flats, storages, parkings, commercials);
    File.WriteAllBytes(filePath, fileBytes);
  }

  public void ExportToZip(string filePath, IEnumerable<(byte[] Body, string Name)> files)
  {
    // var fileBytes = ZipFiles(files);
    // File.WriteAllBytes(filePath, fileBytes);

    using var archive = ZipFile.Open(filePath, ZipArchiveMode.Create);
    foreach (var (Body, Name) in files)
    {
      var entry = archive.CreateEntry(Name);

      using var entryStream = entry.Open();
      entryStream.Write(Body);
    }
  }

  public byte[] ZipFiles(IEnumerable<(byte[] Body, string Name)> files)
  {
    using var compressedFileStream = new MemoryStream();
    using var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, true);
    foreach (var (Body, Name) in files)
    {
      var zipEntry = zipArchive.CreateEntry(Name);
      using var originalFileStream = new MemoryStream(Body);
      using var zipEntryStream = zipEntry.Open();
      originalFileStream.CopyTo(zipEntryStream);
    }

    return compressedFileStream.ToArray();
  }
}