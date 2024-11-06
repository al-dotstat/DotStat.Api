using DotStat.Api.Domain.CommercialAggregate;
using DotStat.Api.Domain.FlatAggregate;
using DotStat.Api.Domain.ParkingAggregate;
using DotStat.Api.Domain.StorageAggregate;
using OfficeOpenXml;

namespace DotStat.Api.Application.Parsing.Export;

public class ExcelExporter : Exporter
{
  private readonly Dictionary<string, string> columnFormat;

  public ExcelExporter()
  {
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    columnFormat = new()
    {
        { "Площадь", "0.00" }, { "Жилая площадь", "0.00" }
    };
  }

  public override byte[] Export(string complex, IEnumerable<Flat> flats, IEnumerable<Storage> storages, IEnumerable<Parking> parkings, IEnumerable<Commercial> commercials)
  {
    var package = new ExcelPackage();
    if (flats.Any()) FillWorksheet(package.Workbook.Worksheets.Add("Квартиры"), TableConverter.FlatsToArray(flats, complex));
    if (storages.Any()) FillWorksheet(package.Workbook.Worksheets.Add("Кладовки"), TableConverter.StoragesToArray(storages, complex));
    if (parkings.Any()) FillWorksheet(package.Workbook.Worksheets.Add("Паркинг"), TableConverter.ParkingsToArray(parkings, complex));
    if (commercials.Any()) FillWorksheet(package.Workbook.Worksheets.Add("Коммерция"), TableConverter.CommercialsToArray(commercials, complex));
    foreach (var worksheet in package.Workbook.Worksheets)
      worksheet.Cells.AutoFitColumns(10, 20);
    return package.GetAsByteArray();
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