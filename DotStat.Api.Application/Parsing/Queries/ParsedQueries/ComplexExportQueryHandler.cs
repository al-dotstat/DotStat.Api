using DotStat.Api.Application.Common.Interfaces.Export;
using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Common.Results;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.ComplexAggregate;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Queries.ParsedQueries;

public class ComplexExportQueryHandler(
  IComplexRepository complexRepository,
  IExporter exporter,
  IFlatRepository flatRepository,
  IParkingRepository parkingRepository,
  IStorageRepository storageRepository,
  ICommercialRepository commercialRepository
) : IRequestHandler<ComplexExportQuery, ErrorOr<FileResult>>
{
  public async Task<ErrorOr<FileResult>> Handle(ComplexExportQuery request, CancellationToken cancellationToken)
  {
    if (await complexRepository.GetByIdAsync(request.ComplexId) is not Complex complex)
      return Errors.Complex.UnknownComplex;

    var flats = request.IncludeFlats ? await flatRepository.GetComplexFlatsAsync(request.ComplexId) : [];
    var parkings = request.IncludeParkings ? await parkingRepository.GetComplexParkingsAsync(request.ComplexId) : [];
    var storages = request.IncludeStorages ? await storageRepository.GetComplexStoragesAsync(request.ComplexId) : [];
    var commercials = request.IncludeCommercials ? await commercialRepository.GetComplexCommercialsAsync(request.ComplexId) : [];

    var fileName = complex.Name + ".xlsx";
    var file = exporter.Export(
      complex.NameRu,
      flats,
      storages,
      parkings,
      commercials
    );

    return new FileResult(file, fileName);
  }
}
