using DotStat.Api.Domain.CommercialAggregate;
using DotStat.Api.Domain.FlatAggregate;
using DotStat.Api.Domain.ParkingAggregate;
using DotStat.Api.Domain.StorageAggregate;
using OfficeOpenXml;

namespace DotStat.Api.Application.Parsing.Export;

public class ExcelExporter : Exporter
{
  private readonly List<string> flatColumns;
  private readonly List<string> nonresidentialColumns;
  private readonly Dictionary<string, string> columnFormat;

  public ExcelExporter()
  {
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    flatColumns = ["ЖК", "Название", "Планировка", "Номер", "Комнатность", "Евро планировка", "Строение", "Этаж", "Площадь", "Жилая площадь"];
    nonresidentialColumns = ["ЖК", "Название", "Планировка", "Номер", "Строение", "Этаж", "Площадь"];
    columnFormat = new()
    {
        { "Площадь", "0.00" }, { "Жилая площадь", "0.00" }
    };
  }

  public override byte[] Export(string complex, IEnumerable<Flat> flats, IEnumerable<Storage> storages, IEnumerable<Parking> parkings, IEnumerable<Commercial> commercials)
  {
    var package = new ExcelPackage();
    if (flats.Any()) FillWorksheet(package.Workbook.Worksheets.Add("Квартиры"), FlatsToArray(flats, complex));
    if (storages.Any()) FillWorksheet(package.Workbook.Worksheets.Add("Кладовки"), StoragesToArray(storages, complex));
    if (parkings.Any()) FillWorksheet(package.Workbook.Worksheets.Add("Паркинг"), ParkingsToArray(parkings, complex));
    if (commercials.Any()) FillWorksheet(package.Workbook.Worksheets.Add("Коммерция"), CommercialsToArray(commercials, complex));
    foreach (var worksheet in package.Workbook.Worksheets)
      worksheet.Cells.AutoFitColumns(10, 20);
    return package.GetAsByteArray();
  }

  private string[,] StoragesToArray(IEnumerable<Storage> storages, string complex)
  {
    var sorted = SortStorages(storages);
    var dates = sorted
        .SelectMany(s => s.ParsingInfos)
        .Select(spi => spi.Date.Date)
        .Distinct()
        .OrderByDescending(d => d)
        .ToList();
    var result = new string[sorted.Count + 1, dates.Count * 2 + nonresidentialColumns.Count];
    FillNonResidentialHeader(result, dates);
    for (var i = 0; i < sorted.Count; i++)
    {
      var storage = sorted[i];
      var orderedStorageInfos = storage.ParsingInfos.OrderByDescending(spi => spi.Date);
      result[i + 1, 0] = complex;
      result[i + 1, 1] = storage.Title;
      result[i + 1, 2] = storage.Layout ?? string.Empty;
      result[i + 1, 3] = orderedStorageInfos.FirstOrDefault(spi => spi.Number != null)?.Number ?? string.Empty;
      result[i + 1, 4] = orderedStorageInfos.FirstOrDefault(spi => spi.Building != null)?.Building ?? string.Empty;
      result[i + 1, 5] = orderedStorageInfos.FirstOrDefault(spi => spi.Floor != null)?.Floor ?? string.Empty;
      result[i + 1, 6] = orderedStorageInfos.FirstOrDefault(spi => spi.Area != null)?.Area!.ToString() ?? string.Empty;
      for (var dateIndex = 0; dateIndex < dates.Count; dateIndex++)
      {
        var dateStorageInfo = orderedStorageInfos.FirstOrDefault(spi => spi.Date.Date == dates[dateIndex].Date);
        if (dateStorageInfo is not null)
        {
          result[i + 1, dateIndex * 2 + nonresidentialColumns.Count] = dateStorageInfo.Price.ToString();
          result[i + 1, dateIndex * 2 + nonresidentialColumns.Count + 1] = dateStorageInfo.Status.ToString();
        }
      }
    }
    return result;
  }

  private string[,] ParkingsToArray(IEnumerable<Parking> parkings, string complex)
  {
    var sorted = SortParkings(parkings);
    var dates = sorted
        .SelectMany(p => p.ParsingInfos)
        .Select(ppi => ppi.Date.Date)
        .Distinct()
        .OrderByDescending(d => d)
        .ToList();
    var result = new string[sorted.Count + 1, dates.Count * 2 + nonresidentialColumns.Count];
    FillNonResidentialHeader(result, dates);
    for (var i = 0; i < sorted.Count; i++)
    {
      var parking = sorted[i];
      var orderedParkingInfos = parking.ParsingInfos.OrderByDescending(ppi => ppi.Date);
      result[i + 1, 0] = complex;
      result[i + 1, 1] = parking.Title;
      result[i + 1, 2] = parking.Layout ?? string.Empty;
      result[i + 1, 3] = orderedParkingInfos.FirstOrDefault(ppi => ppi.Number != null)?.Number ?? string.Empty;
      result[i + 1, 4] = orderedParkingInfos.FirstOrDefault(ppi => ppi.Building != null)?.Building ?? string.Empty;
      result[i + 1, 5] = orderedParkingInfos.FirstOrDefault(ppi => ppi.Floor != null)?.Floor ?? string.Empty;
      result[i + 1, 6] = orderedParkingInfos.FirstOrDefault(ppi => ppi.Area != null)?.Area!.ToString() ?? string.Empty;
      for (var dateIndex = 0; dateIndex < dates.Count; dateIndex++)
      {
        var dateParkingInfo = orderedParkingInfos.FirstOrDefault(fpi => fpi.Date.Date == dates[dateIndex].Date);
        if (dateParkingInfo is not null)
        {
          result[i + 1, dateIndex * 2 + nonresidentialColumns.Count] = dateParkingInfo.Price.ToString();
          result[i + 1, dateIndex * 2 + nonresidentialColumns.Count + 1] = dateParkingInfo.Status.ToString();
        }
      }
    }
    return result;
  }

  private string[,] CommercialsToArray(IEnumerable<Commercial> commercials, string complex)
  {
    var sorted = SortCommercials(commercials);
    var dates = sorted
        .SelectMany(c => c.ParsingInfos)
        .Select(cpi => cpi.Date.Date)
        .Distinct()
        .OrderByDescending(d => d)
        .ToList();
    var result = new string[sorted.Count + 1, dates.Count * 2 + nonresidentialColumns.Count];
    FillNonResidentialHeader(result, dates);
    for (var i = 0; i < sorted.Count; i++)
    {
      var commercial = sorted[i];
      var orderedCommercialInfos = commercial.ParsingInfos.OrderByDescending(cpi => cpi.Date);
      result[i + 1, 0] = complex;
      result[i + 1, 1] = commercial.Title;
      result[i + 1, 2] = commercial.Layout ?? string.Empty;
      result[i + 1, 3] = orderedCommercialInfos.FirstOrDefault(cpi => cpi.Number != null)?.Number ?? string.Empty;
      result[i + 1, 4] = orderedCommercialInfos.FirstOrDefault(cpi => cpi.Building != null)?.Building ?? string.Empty;
      result[i + 1, 5] = orderedCommercialInfos.FirstOrDefault(cpi => cpi.Floor != null)?.Floor ?? string.Empty;
      result[i + 1, 6] = orderedCommercialInfos.FirstOrDefault(cpi => cpi.Area != null)?.Area!.ToString() ?? string.Empty;
      for (var dateIndex = 0; dateIndex < dates.Count; dateIndex++)
      {
        var dateCommercialInfo = orderedCommercialInfos.FirstOrDefault(cpi => cpi.Date.Date == dates[dateIndex].Date);
        if (dateCommercialInfo is not null)
        {
          result[i + 1, dateIndex * 2 + nonresidentialColumns.Count] = dateCommercialInfo.Price.ToString();
          result[i + 1, dateIndex * 2 + nonresidentialColumns.Count + 1] = dateCommercialInfo.Status.ToString();
        }
      }
    }
    return result;
  }

  private string[,] FlatsToArray(IEnumerable<Flat> flats, string complex)
  {
    var sorted = SortFlats(flats);
    var dates = sorted
        .SelectMany(f => f.ParsingInfos)
        .Select(fpi => fpi.Date.Date)
        .Distinct()
        .OrderByDescending(d => d)
        .ToList();

    var result = new string[sorted.Count + 1, dates.Count * 2 + flatColumns.Count];
    FillHeader(result, dates);
    for (var i = 0; i < sorted.Count; i++)
    {
      var flat = sorted[i];
      var orderedFlatInfos = flat.ParsingInfos.OrderByDescending(fpi => fpi.Date);
      result[i + 1, 0] = complex;
      result[i + 1, 1] = flat.Title;
      result[i + 1, 2] = flat.Layout ?? string.Empty;
      result[i + 1, 3] = orderedFlatInfos.FirstOrDefault(fpi => fpi.Number != null)?.Number ?? string.Empty;
      result[i + 1, 4] = orderedFlatInfos.FirstOrDefault(fpi => fpi.Roominess != null)?.Roominess ?? string.Empty;
      result[i + 1, 5] = flat.IsEuro.HasValue ? flat.IsEuro.Value ? "1" : "0" : string.Empty;
      result[i + 1, 6] = orderedFlatInfos.FirstOrDefault(fpi => fpi.Building != null)?.Building ?? string.Empty;
      result[i + 1, 7] = orderedFlatInfos.FirstOrDefault(fpi => fpi.Floor != null)?.Floor ?? string.Empty;
      result[i + 1, 8] = orderedFlatInfos.FirstOrDefault(fpi => fpi.Area != null)?.Area!.ToString() ?? string.Empty;
      result[i + 1, 9] = orderedFlatInfos.FirstOrDefault(fpi => fpi.LivingArea != null)?.LivingArea!.ToString() ?? string.Empty;
      for (var dateIndex = 0; dateIndex < dates.Count; dateIndex++)
      {
        var dateFlatInfo = orderedFlatInfos.FirstOrDefault(fpi => fpi.Date.Date == dates[dateIndex].Date);
        if (dateFlatInfo is not null)
        {
          result[i + 1, dateIndex * 2 + flatColumns.Count] = dateFlatInfo.Price.ToString();
          result[i + 1, dateIndex * 2 + flatColumns.Count + 1] = dateFlatInfo.Status.ToString();
        }
      }
    }
    return result;
  }

  private void FillHeader(string[,] arr, IEnumerable<DateTime> dates)
  {
    var datesColumns = dates.SelectMany(d => new string[] { $"{d:dd.MM.yyyy} Цена", $"{d:dd.MM.yyyy} Статус" });
    var headers = flatColumns
        .Concat(datesColumns)
        .ToList();

    for (var i = 0; i < headers.Count; i++)
      arr[0, i] = headers[i];
  }

  private void FillNonResidentialHeader(string[,] arr, IEnumerable<DateTime> dates)
  {
    var datesColumns = dates.SelectMany(d => new string[] { $"{d:dd.MM.yyyy} Цена", $"{d:dd.MM.yyyy} Статус" });
    var headers = nonresidentialColumns
        .Concat(datesColumns)
        .ToList();

    for (var i = 0; i < headers.Count; i++)
      arr[0, i] = headers[i];
  }

  private static List<Flat> SortFlats(IEnumerable<Flat> flats)
  {
    var sorted = flats.ToList();
    sorted.Sort((x, y) =>
    {
      var xMinDate = x.ParsingInfos.Max(fpi => fpi.Date);
      var yMinDate = y.ParsingInfos.Max(fpi => fpi.Date);

      if (xMinDate < yMinDate) return 1;
      else if (xMinDate > yMinDate) return -1;
      else return 0;
    });
    return sorted;
  }

  private static List<Storage> SortStorages(IEnumerable<Storage> storages)
  {
    var sorted = storages.ToList();
    sorted.Sort((x, y) =>
    {
      var xMinDate = x.ParsingInfos.Max(fpi => fpi.Date);
      var yMinDate = y.ParsingInfos.Max(fpi => fpi.Date);

      if (xMinDate > yMinDate) return 1;
      else if (xMinDate < yMinDate) return -1;
      else return 0;
    });
    return sorted;
  }

  private static List<Parking> SortParkings(IEnumerable<Parking> parkings)
  {
    var sorted = parkings.ToList();
    sorted.Sort((x, y) =>
    {
      var xMinDate = x.ParsingInfos.Max(fpi => fpi.Date);
      var yMinDate = y.ParsingInfos.Max(fpi => fpi.Date);

      if (xMinDate > yMinDate) return 1;
      else if (xMinDate < yMinDate) return -1;
      else return 0;
    });
    return sorted;
  }

  private static List<Commercial> SortCommercials(IEnumerable<Commercial> commercials)
  {
    var sorted = commercials.ToList();
    sorted.Sort((x, y) =>
    {
      var xMinDate = x.ParsingInfos.Max(cpi => cpi.Date);
      var yMinDate = y.ParsingInfos.Max(cpi => cpi.Date);

      if (xMinDate > yMinDate) return 1;
      else if (xMinDate < yMinDate) return -1;
      else return 0;
    });
    return sorted;
  }

  private void FillWorksheet(ExcelWorksheet worksheet, string[,] data)
  {
    for (int i = 0; i <= data.GetUpperBound(0); i++)
    {
      for (int j = 0; j <= data.GetUpperBound(1); j++)
      {
        var cellData = data[i, j];
        if (double.TryParse(cellData, out var cellDataDouble))
          worksheet.Cells[i + 1, j + 1].Value = cellDataDouble;
        else
          worksheet.Cells[i + 1, j + 1].Value = cellData;
        if (i == 0)
          continue;

        if (columnFormat.ContainsKey(data[0, j]))
          worksheet.Cells[i + 1, j + 1].Style.Numberformat.Format = columnFormat[data[0, j]];
        else if (data[0, j].Split().Last() == "Цена")
          worksheet.Cells[i + 1, j + 1].Style.Numberformat.Format = "0.00";
      }
    }
  }
}